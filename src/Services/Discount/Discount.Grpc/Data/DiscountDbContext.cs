using Discount.Grpc.Model;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;
public class DiscountDbContext : DbContext
{
	public DiscountDbContext(DbContextOptions<DiscountDbContext> options) 
		: base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Coupon>().HasData(
			new Coupon {Id = 1 , ProductName = "IPhone X" , Description = "" , Amount = 10} ,
			new Coupon { Id = 2 , ProductName = "Samsung x" , Description = "" , Amount = 5}
			);
	}
	public DbSet<Coupon> Coupons { get; set; }
}