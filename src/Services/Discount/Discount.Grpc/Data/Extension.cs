using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;
public static class Extension
{
	public static IApplicationBuilder UseMigration(this IApplicationBuilder builder)
	{
		using var scope = builder.ApplicationServices.CreateScope();
		using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountDbContext>();
		dbContext.Database.MigrateAsync();
		return builder;
	}
}