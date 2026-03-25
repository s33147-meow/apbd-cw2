namespace Tmp.Models;

public class DevicePhone(string name, DevicePhone.OS os, int osVersion) : Device(name) {
	public enum OS {
		IOs,
		Android
	}

	public OS OperatingSystem {get; set;} = os;
	public int OperatingSystemVersion {get; set;} = osVersion;

	public override string ToString() {
		return base.ToString() + $"| OS = {OperatingSystem}; OS Version = {OperatingSystemVersion}";
	}
}
