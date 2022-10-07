namespace ManageUserApi.Interfaces;

public interface IUserRepo
{
	Task<User?> GetUserAsync(int id);

	Task<List<User>> GetUsersAsync();
	
	Task RemoveUserAsync(int id);

	Task UpdateUserAsync(User updateUser);

	Task AddUserAsync(User user);
}
