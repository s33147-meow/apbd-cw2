using Tmp.Data;
using Tmp.Exceptions;
using Tmp.Models;
using Tmp.Services.Logging;

namespace Tmp.Services;

public class LeaseService(ILogger logger, UserService users, DeviceService devices, float penaltyMultiplier = 1) {
	private readonly float m_penaltyMultiplier = penaltyMultiplier; // should be in some sort of config file, but for a single variable it makes little sense and it is too late for that now
	private readonly ILogger m_logger = logger;
	private readonly UserService m_users = users;
	private readonly DeviceService m_devices = devices;
	private readonly Dictionary<Guid, Lease> m_leases = new();
	private readonly Random m_rng = new();

	public LeaseDto BeginLease(UserDto user, DeviceDto device, DateTime begin, DateTime plannedReturn) {
		if(IsLeased(device, begin)) throw new LeaseInvalidException(); // we dont expect for leases to be planned ahead so no need for availability check
		if(m_devices.GetDevice(device).State != DeviceState.Normal) throw new DeviceStateInvalidException();
		if(FindUserLeases(user).Count() > m_users.GetUser(user).LeaseMax) throw new LeaseInvalidException();

		var l = new Lease(user, device) {
			Start = begin,
			PlannedReturn = plannedReturn
		};

		m_logger.LogTrace($"Begin {l.User.UserName}'s lease of device {l.Device.Name}");

		m_leases.Add(l.Id, l);
		return l.DTO();
	}

	public LeaseDto EndLease(LeaseDto lease, DateTime end) {
		var l = GetLease(lease);
		l.Return = end;

		m_logger.LogTrace($"End {l.User.UserName}'s lease of device {l.Device.Name}");

		if(end > l.PlannedReturn) {
			l.Penalty = (int)(((end - l.PlannedReturn).TotalDays) * m_penaltyMultiplier);
			m_logger.LogTrace($"Overdue penalty charged: {l.Penalty:0.00} PLN");
		}

		m_devices.SetDeviceState(l.Device, m_rng.Next(0, 8) switch {
			< 5 => DeviceState.Normal,
			< 7 => DeviceState.RequiresService,
			_ => DeviceState.Obliterated
		});

		return l.DTO();
	}

	public Lease GetLease(LeaseDto dto) {
		return m_leases[dto.Id];
	}

	public bool IsLeased(DeviceDto device, DateTime when) {
		return m_leases.Any(lease => when >= lease.Value.Start && when <= (lease.Value.Return ?? DateTime.MaxValue));
	}

	public IEnumerable<LeaseDto> FindUserLeases(UserDto user) {
		return m_leases.Where(lease => lease.Value.User == user).Select(lease => lease.Value.DTO());
	}

	public void LogAllLeases() {
		var leaseList = m_leases.Values.OrderBy(l => l.Start);
		m_logger.LogInfo("Leases ------------------------------------------------");
		foreach(var l in leaseList) {
			m_logger.LogInfo("\t" + l);
		}
	}
}
