namespace ManageUserApi.Entities;

public class User
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? SurName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string? Email { get; set; }
	public string? PhoneNumber { get; set; }
}
