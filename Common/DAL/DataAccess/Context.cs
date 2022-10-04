using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataAccess
{
	public class Context : DbContext
	{
		public Context(DbContextOptions options) : base(options) { }

		public DbSet<Student> Students { get; set; } = null!;
	}
}
