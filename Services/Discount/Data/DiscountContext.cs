using Discount.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Data
{
   public class DiscountContext : DbContext
   {
      public DbSet<Coupon> Coupons { get; set; }

      public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
      {
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "Iphone X", Description = "Iphone Description x", Amount = 2000 },
            new Coupon { Id = 2, ProductName = "Iphone 2", Description = "Iphone Description x", Amount = 900 }
         );
      }
   }
}
