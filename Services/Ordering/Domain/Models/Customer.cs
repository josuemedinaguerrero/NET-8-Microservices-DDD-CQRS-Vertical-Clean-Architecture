using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Models
{
   public class Customer : Entity<CustomerId>
   {
      public string Name { get; private set; } = "";
      public string Email { get; private set; } = "";

      public static Customer Create(CustomerId id, string name, string email)
      {
         ArgumentException.ThrowIfNullOrWhiteSpace(name);
         ArgumentException.ThrowIfNullOrWhiteSpace(email);

         return new Customer { Id = id, Name = name, Email = email };
      }
   }
}
