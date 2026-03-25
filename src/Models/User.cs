using Tmp.Data;

namespace Tmp.Models;

public abstract class User(string firstName, string lastName) {
	public Guid Id {get; private set;} = Guid.NewGuid();
	public string FirstName {get; private set;} = firstName;
	public string LastName {get; private set;} = lastName;
	public abstract int LeaseMax {get;}

	public UserDto DTO() => new UserDto(Id, $"{LastName} {FirstName}");
}
