using Domain.Abstractions;
using Domain.Models;

namespace Domain.Events
{
   public record OrderUpdateEvent(Order order) : IDomainEvent
   {
   }
}
