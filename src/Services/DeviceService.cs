using Tmp.Data;
using Tmp.Models;

namespace Tmp.Services;

public class DeviceService {
	private readonly Dictionary<Guid, Device> m_devices = new();

	public DeviceDto AddDevice(DeviceCreator deviceData) {
		var device = deviceData();
		m_devices.Add(device.Id, device);

		return device.DTO();
	}

	public Device GetDevice(DeviceDto dto) {
		return m_devices[dto.Id];
	}

}
