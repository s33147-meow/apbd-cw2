using Tmp.Data;

namespace Tmp.Models;

public abstract class Device(string name) {
	public Guid Id {get; private set;} = Guid.NewGuid();
	public string Name {get; private set;} = name;
	public DeviceState State {get; set;}

	public DeviceDto DTO() {
		return new DeviceDto(Id, Name);
	}
}
