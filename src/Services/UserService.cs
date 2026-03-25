using Tmp.Models;
using Tmp.Services.Logging;

namespace Tmp.Services;

public class UserService(ILogger logger) {
	private readonly Dictionary<Guid, User> m_users = new();
	private readonly ILogger m_logger = logger;

	public UserStudent RegisterStudent(string firstName, string lastName, string studentNumber) {
		var user = new UserStudent(firstName, lastName, studentNumber);
		m_users.Add(user.Id, user);
		return user;
	}

	public UserEmployee RegisterEmployee(string firstName, string lastName) {
		var user = new UserEmployee(firstName, lastName);
		m_users.Add(user.Id, user);
		return user;
	}
}
