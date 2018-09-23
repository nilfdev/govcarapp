using carbase.Models;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
	public class GovCarDbContext : DbContext
	{
		public GovCarDbContext(DbContextOptions options)
			: base(options)
		{
			
		}

		public DbSet<RegistrationLine> RegistrationLines { get; set; }
	}
}
