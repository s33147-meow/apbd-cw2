namespace Tmp.Models;

public abstract class User(string firstName, string lastName) {
	public Guid Id {get; private set;} = Guid.NewGuid();
	public string FirstName {get; set;} = firstName;
	public string LastName {get; set;} = lastName;
	public abstract int LeaseMax {get;}
}
