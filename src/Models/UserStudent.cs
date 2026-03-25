namespace Tmp.Models;

public class UserStudent(string firstName, string lastName, string studentNumber) : User(firstName, lastName) {
	public string StudentNumber {get; set;} = studentNumber;
	public override int LeaseMax => throw new NotImplementedException();
}
