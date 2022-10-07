using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataAccess
{
	public class ContextDb : DbContext
	{
		public ContextDb(DbContextOptions options) : base(options) { }

		public DbSet<Student> Students { get; set; } = null!;
	}
}
