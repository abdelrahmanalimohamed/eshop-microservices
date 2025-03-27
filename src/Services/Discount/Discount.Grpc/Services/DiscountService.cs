using Discount.Grpc.Data;
using Discount.Grpc.Model;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
namespace Discount.Grpc.Services;
public class DiscountService(DiscountDbContext dbContext, ILogger<DiscountService> logger)
	: DiscountProtoService.DiscountProtoServiceBase
{
	public override async Task<CouponModel> CreateDiscount
		(CreateDiscountRequest request,
		ServerCallContext context)
	{
		var coupon = request.Coupon.Adapt<Coupon>();
		if (coupon is null)
			throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));

		dbContext.Coupons.Add(coupon);
		await dbContext.SaveChangesAsync();

		return coupon.Adapt<CouponModel>();
	}
	public override async Task<DeleteDiscountResponse> DeleteDiscount
		(DeleteDiscountRequest request,
		ServerCallContext context)
	{
		var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

		if (coupon is null)
			throw new RpcException(new Status(StatusCode.NotFound, $"Discount for {request.ProductName} is not found"));

		dbContext.Coupons.Remove(coupon);
		await dbContext.SaveChangesAsync();

		return new DeleteDiscountResponse { Sucess = true };
	}
	public override async Task<CouponModel> GetDiscount
		(GetDiscountRequest request,
		ServerCallContext context)
	{
		var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

		if (coupon is null)
			coupon = new Coupon { ProductName = "No Product Found" };

		logger.LogInformation("Dicount is retrieved for Product Name {productName}", coupon.ProductName);

		return coupon.Adapt<CouponModel>();
	}
	public override async Task<CouponModel> UpdateDiscount
		(UpdateDiscountRequest request,
		ServerCallContext context)
	{
		var coupon = request.Coupon.Adapt<Coupon>();
		if (coupon is null)
			throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));

		dbContext.Coupons.Update(coupon);
		await dbContext.SaveChangesAsync();

		return coupon.Adapt<CouponModel>();
	}
}