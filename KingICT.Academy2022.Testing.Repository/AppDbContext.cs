using KingICT.Academy2022.Testing.Model;
using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy2022.Testing.Repository
{
	public class AppDbContext : DbContext
	{
		#region Properties

		public virtual DbSet<Customer> Customers { get; set; }

		#endregion

		#region Constructors

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		#endregion
	}
}
