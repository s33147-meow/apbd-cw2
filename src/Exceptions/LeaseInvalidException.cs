namespace Tmp.Exceptions;

[Serializable]
public class LeaseInvalidException : Exception {
    public LeaseInvalidException() { }
    public LeaseInvalidException(string message) : base(message) { }
}
