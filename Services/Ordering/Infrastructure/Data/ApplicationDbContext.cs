using System.Reflection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

      public DbSet<Customer> Customers => Set<Customer>();
      public DbSet<Product> Product => Set<Product>();
      public DbSet<Order> Order => Set<Order>();
      public DbSet<OrderItem> OrderItems => Set<OrderItem>();

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         base.OnModelCreating(modelBuilder);
      }
   }
}
