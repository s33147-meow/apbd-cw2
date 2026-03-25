using Tmp.Data;

namespace Tmp.Models;

public class Lease(UserDto user, DeviceDto device) {
	public Guid Id {get; set;} = Guid.NewGuid();
	public UserDto User {get; init;} = user;
	public DeviceDto Device {get; init;} = device;
	public DateTime Start {get; init;}
	public DateTime PlannedReturn {get; init;}
	public DateTime? Return {get; set;}
	public int Penalty {get; set;}

	public LeaseDto DTO() => new LeaseDto(Id);

	public override string ToString() {
		if(Penalty > 0)
			return $"Lase of {Device.Name, 20} to {User.UserName, 20} | {Start} - {Return} ({PlannedReturn}) [ {Penalty} PLN Penalty ]";
		else
			return $"Lase of {Device.Name, 20} to {User.UserName, 20} | {Start} - {Return} ({PlannedReturn})";
	}
}
