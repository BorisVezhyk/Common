namespace ManageUserApi.Interfaces;

public interface IUserRepo
{
	/// <summary>Gets the user asynchronous.</summary>
	/// <param name="id">The identifier of user.</param>
	Task<User?> GetUserAsync(int id);

	/// <summary>
	/// Gets the users asynchronous.
	/// </summary>
	Task<List<User>> GetUsersAsync();

	/// <summary>
	/// Removes the user asynchronous.
	/// </summary>
	/// <param name="id">The identifier of user.</param>
	Task RemoveUserAsync(int id);

	/// <summary>
	/// Updates the user asynchronous.
	/// </summary>
	/// <param name="updateUser">The update user.</param>
	Task UpdateUserAsync(User updateUser);

	/// <summary>
	/// Adds the user asynchronous.
	/// </summary>
	/// <param name="user">The user.</param>
	Task AddUserAsync(User user);
}
