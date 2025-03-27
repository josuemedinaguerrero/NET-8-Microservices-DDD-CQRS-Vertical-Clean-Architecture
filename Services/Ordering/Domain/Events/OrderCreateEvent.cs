using Domain.Abstractions;
using Domain.Models;

namespace Domain.Events
{
   public record OrderCreateEvent(Order order) : IDomainEvent
   {
   }
}
