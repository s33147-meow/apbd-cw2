namespace Tmp.Exceptions;

[Serializable]
public class DeviceStateInvalidException : Exception {
    public DeviceStateInvalidException() { }
    public DeviceStateInvalidException(string message) : base(message) { }
}
