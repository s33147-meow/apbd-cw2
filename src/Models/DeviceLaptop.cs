namespace Tmp.Models;

public class DeviceLaptop(string name, DeviceLaptop.OS os, bool dgpu) : Device(name) {
	public enum OS {
		Windows,
		Mac,
		Linux
	}

	public OS OperatingSystem {get; set;} = os;
	public bool DedicatedGpu {get; set;} = dgpu;
}
