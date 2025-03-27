using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Models
{
   public class Product : Entity<ProductId>
   {
      public string Name { get; private set; } = "";
      public decimal Price { get; private set; } = default;

      public static Product Create(ProductId id, string name, decimal price)
      {
         ArgumentException.ThrowIfNullOrWhiteSpace(name);
         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

         return new Product { Id = id, Name = name, Price = price };
      }
   }
}
