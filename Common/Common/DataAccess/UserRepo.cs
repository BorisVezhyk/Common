namespace ManageUserApi.DataAccess;

public class UserRepo : IUserRepo
{
	private readonly UserContext _db;

	public UserRepo(UserContext db)
	{
		_db = db ?? throw new ArgumentNullException(nameof(db));
	}

	public async Task AddUserAsync(User user)
	{
		await _db.Users.AddAsync(user);
		await _db.SaveChangesAsync();
	}

	public async Task<User?> GetUserAsync(int id)
	{
		return await _db.Users.FindAsync(id);
	}

	public async Task<List<User>> GetUsersAsync()
	{
		return await _db.Users.ToListAsync();
	}

	public async Task RemoveUserAsync(int id)
	{
		User? user = await _db.Users.FindAsync(id);
		if (user is null)
		{
			throw new InvalidOperationException(nameof(user));
		}

		_db.Users.Remove(user);
		await _db.SaveChangesAsync();
	}

	public async Task UpdateUserAsync(User updateUser)
	{
		User? user = await _db.Users.FindAsync(updateUser.Id);

		if (user is null)
		{
			throw new InvalidOperationException(nameof(user));
		}

		user.Name = updateUser.Name;
		user.SurName = updateUser.SurName;
		user.PhoneNumber = updateUser.PhoneNumber;
		user.DateOfBirth = updateUser.DateOfBirth;
		user.Email = updateUser.Email;

		await _db.SaveChangesAsync();
	}
}
