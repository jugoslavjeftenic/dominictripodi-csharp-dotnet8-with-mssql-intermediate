using Microsoft.EntityFrameworkCore;
using T036_EntityFramework.Models;

namespace T036_EntityFramework.Data
{
	internal class DataContextEF : DbContext
	{
		public DbSet<ComputerModel> Computer { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(connectionString,
					optionsBuilder => optionsBuilder.EnableRetryOnFailure());
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			string schemaName = "TutorialAppSchema";
			modelBuilder.HasDefaultSchema(schemaName);

			//string tableName = "Computer";
			//modelBuilder.Entity<ComputerModel>().ToTable(tableName, schemaName);

			modelBuilder.Entity<ComputerModel>();
			//modelBuilder.Entity<ComputerModel>().HasNoKey();
			//modelBuilder.Entity<ComputerModel>().HasKey(c => c.ComputerId);
		}
	}
}
