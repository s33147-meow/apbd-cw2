using Tmp.Data;
using Tmp.Models;
using Tmp.Services.Logging;

namespace Tmp.Services;

public class UserService(ILogger logger) {
	private readonly Dictionary<Guid, User> m_users = new();
	private readonly ILogger m_logger = logger;

	public UserDto RegisterStudent(string firstName, string lastName, string studentNumber) {
		var user = new UserStudent(firstName, lastName, studentNumber);
		m_users.Add(user.Id, user);
		return user.DTO();
	}

	public UserDto RegisterEmployee(string firstName, string lastName) {
		var user = new UserEmployee(firstName, lastName);
		m_users.Add(user.Id, user);
		return user.DTO();
	}

	public User GetUser(UserDto user) {
		return m_users[user.Id];
	}
}
