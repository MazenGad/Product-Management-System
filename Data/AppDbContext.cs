using Microsoft.EntityFrameworkCore;
using Product_Management_System.Entities;

namespace Product_Management_System.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.HasMany(e=>e.Transactions)
				.WithOne(e => e.Product)
				.HasForeignKey(e => e.ProductId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Product>()
				.Property(p => p.GeneratedCode)
				.HasMaxLength(50)
				.IsRequired();

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<ProductTransaction> ProductTransactions { get; set; }
	}
}
