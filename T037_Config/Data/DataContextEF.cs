using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using T037_Config.Models;

namespace T037_Config.Data
{
	internal class DataContextEF(IConfiguration config) : DbContext
	{
		private readonly IConfiguration _config = config;

		public DbSet<ComputerModel> Computer { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
					optionsBuilder => optionsBuilder.EnableRetryOnFailure());
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			string schemaName = "TutorialAppSchema";
			modelBuilder.HasDefaultSchema(schemaName);

			modelBuilder.Entity<ComputerModel>();
		}
	}
}
