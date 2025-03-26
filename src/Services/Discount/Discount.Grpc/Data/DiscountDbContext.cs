using Discount.Grpc.Model;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
	public class DiscountDbContext : DbContext
	{
		public DbSet<Coupon> Coupons { get; set; }
		public DiscountDbContext(DbContextOptions<DiscountDbContext> options) 
			: base(options)
		{
			
		}
	}
}