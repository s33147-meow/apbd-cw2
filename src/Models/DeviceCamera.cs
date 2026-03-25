namespace Tmp.Models;

public class DeviceCamera(string name, DeviceCamera.Kind kind) : Device(name) {
	public enum Kind {
		Film,
		DSLR
	}

	public Kind CameraKind {get; set;} = kind;

}
