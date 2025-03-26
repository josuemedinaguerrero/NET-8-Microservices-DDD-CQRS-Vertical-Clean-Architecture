using Discount.Data;
using Discount.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Services
{
   public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
      : DiscountProtoService.DiscountProtoServiceBase
   {
      public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
      {
         var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
         coupon ??= new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };

         logger.LogInformation("Discount is retrieved for ProductName: {productName}, Amount: {amount}", coupon.ProductName, coupon.Amount);

         var couponModel = coupon.Adapt<CouponModel>();
         return couponModel;
      }

      public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
      {
         var coupon = request.Coupon.Adapt<Coupon>() ?? throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

         await dbContext.Coupons.AddAsync(coupon);
         await dbContext.SaveChangesAsync();

         logger.LogInformation("Discount is successfully created. ProductName: {productName}, Amount: {amount}", coupon.ProductName, coupon.Amount);

         var couponModel = coupon.Adapt<CouponModel>();
         return couponModel;
      }

      public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
      {
         var coupon = request.Coupon.Adapt<Coupon>() ?? throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

         dbContext.Coupons.Update(coupon);
         await dbContext.SaveChangesAsync();

         logger.LogInformation("Discount is successfully updated. ProductName: {productName}, Amount: {amount}", coupon.ProductName, coupon.Amount);

         var couponModel = coupon.Adapt<CouponModel>();
         return couponModel;
      }

      public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
      {
         var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName)
            ?? throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName = {request.ProductName} is not found."));

         dbContext.Coupons.Remove(coupon);
         await dbContext.SaveChangesAsync();

         logger.LogInformation("Discount is successfully deleted. ProductName: {productName}, Amount: {amount}", coupon.ProductName, coupon.Amount);

         return new DeleteDiscountResponse { Success = true };
      }
   }
}
