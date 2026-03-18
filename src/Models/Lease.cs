namespace Tmp.Models;

public record class Lease(User user, Device device, DateTime start, DateTime? end);
