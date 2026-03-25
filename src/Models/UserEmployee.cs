namespace Tmp.Models;

public class UserEmployee(string firstName, string lastName) : User(firstName, lastName) {
	public override int LeaseMax => 5;
}
