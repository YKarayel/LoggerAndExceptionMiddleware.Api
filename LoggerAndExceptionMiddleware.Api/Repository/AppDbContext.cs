using LoggerAndExceptionMiddleware.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace LoggerAndExceptionMiddleware.Api.Repository
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Products>().HasData(new Products()
			{
				Id = 1,
				Name = "Kalem"
			},
			new Products()
			{
				Id = 2,
				Name = "Silgi"
			});

			
		}
		public DbSet<Products> Products { get; set; }	
	}
}
