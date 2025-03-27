using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Models
{
   public class OrderItem : Entity<OrderItemId>
   {
      internal OrderItem(OrderId orderId, ProductId producId, int quantity, decimal price)
      {
         Id = OrderItemId.Of(Guid.NewGuid());
         OrderId = orderId;
         ProductId = producId;
         Quantity = quantity;
         Price = price;

      }
      public OrderId OrderId { get; private set; }
      public ProductId ProductId { get; private set; }
      public int Quantity { get; private set; } = default;
      public decimal Price { get; private set; } = default;
   }
}
