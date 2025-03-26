namespace Ordering
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddApiServices(this IServiceCollection services)
      {
         // services.AddCarter();

         return services;
      }

      public static WebApplication UseApiServices(this WebApplication app)
      {
         // services.AddCarter();

         return app;
      }
   }
}
