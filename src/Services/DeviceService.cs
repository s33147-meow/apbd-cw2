using Tmp.Data;
using Tmp.Models;
using Tmp.Services.Logging;

namespace Tmp.Services;

public class DeviceService(ILogger logger) {
	private readonly Dictionary<Guid, Device> m_devices = new();
	private readonly ILogger m_logger = logger;

	public DeviceDto AddDevice(DeviceCreator deviceData) {
		var device = deviceData();
		m_devices.Add(device.Id, device);
		m_logger.LogTrace($"Device {device.Name} created");

		return device.DTO();
	}

	public Device GetDevice(DeviceDto dto) {
		return m_devices[dto.Id];
	}

	public DeviceDto SetDeviceState(DeviceDto device, DeviceState state) {
		var d = GetDevice(device);
		d.State = state;
		m_logger.LogTrace($"Device {device.Name} is now {state}");
		return d.DTO();
	}

	internal void LogAllDevices() {
		m_logger.LogInfo("Devices ------------------------------------------------");
		foreach(var l in m_devices.Values) {
			m_logger.LogInfo("\t" + l);
		}
	}
}
