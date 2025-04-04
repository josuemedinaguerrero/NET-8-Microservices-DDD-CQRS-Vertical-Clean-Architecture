using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ordering.Infrastructure.Data.Configurations
{
   public class OrderConfiguration : IEntityTypeConfiguration<Order>
   {
      public void Configure(EntityTypeBuilder<Order> builder)
      {
         builder.HasKey(o => o.Id);

         builder.Property(o => o.Id).HasConversion(orderId => orderId.Value, dbId => OrderId.Of(dbId));

         builder.HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId);

         builder.HasMany(o => o.OrderItems).WithOne().HasForeignKey(oi => oi.OrderId);

         builder.ComplexProperty(o => o.OrderName, nameBuilder =>
         {
            nameBuilder.Property(n => n.Value)
               .HasColumnName(nameof(Order.OrderName))
               .HasMaxLength(100)
               .IsRequired();
         });


         builder.ComplexProperty(o => o.ShippingAddress, addressBuilder =>
         {
            addressBuilder.Property(a => a.FirstName)
               .HasMaxLength(50)
               .IsRequired();

            addressBuilder.Property(a => a.LastName)
               .HasMaxLength(50)
               .IsRequired();

            addressBuilder.Property(a => a.EmailAddress)
               .HasMaxLength(50)
               .IsRequired();

            addressBuilder.Property(a => a.AddressLine)
               .HasMaxLength(180)
               .IsRequired();

            addressBuilder.Property(a => a.Country)
               .HasMaxLength(50);

            addressBuilder.Property(a => a.State)
               .HasMaxLength(50);

            addressBuilder.Property(a => a.ZipCode)
               .HasMaxLength(5)
               .IsRequired();
         });

         builder.ComplexProperty(o => o.BillingAddress, billingAddress =>
         {
            billingAddress.Property(a => a.FirstName)
               .HasMaxLength(50)
               .IsRequired();

            billingAddress.Property(a => a.LastName)
               .HasMaxLength(50)
               .IsRequired();

            billingAddress.Property(a => a.EmailAddress)
               .HasMaxLength(50)
               .IsRequired();

            billingAddress.Property(a => a.AddressLine)
               .HasMaxLength(180)
               .IsRequired();

            billingAddress.Property(a => a.Country)
               .HasMaxLength(50);

            billingAddress.Property(a => a.State)
               .HasMaxLength(50);

            billingAddress.Property(a => a.ZipCode)
               .HasMaxLength(5)
               .IsRequired();
         });

         builder.ComplexProperty(o => o.Payment, payment =>
         {
            payment.Property(a => a.CardName)
               .HasMaxLength(50);

            payment.Property(a => a.CardNumber)
               .HasMaxLength(24)
               .IsRequired();

            payment.Property(a => a.Expiration)
               .HasMaxLength(10);

            payment.Property(a => a.CVV)
               .HasMaxLength(3);

            payment.Property(a => a.PaymentMethod);
         });

         builder.Property(s => s.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(x => x.ToString(), dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

         builder.Property(o => o.TotalPrice);
      }
   }
}
