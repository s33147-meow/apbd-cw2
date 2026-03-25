using Tmp.Data;
using Tmp.Models;
using Tmp.Services.Logging;

namespace Tmp.Services;

public class LeaseService(ILogger logger, UserService users, DeviceService devices) {
	private readonly ILogger m_logger = logger;
	private readonly UserService m_users = users;
	private readonly DeviceService m_devices = devices;
	private readonly List<Lease> m_leases = new();

	public LeaseDto BeginLease(UserDto user, DeviceDto device, DateTime begin) {
		return new LeaseDto();
	}

	public LeaseDto EndLease(LeaseDto lease, DateTime end) {
		return new LeaseDto();
	}
}
