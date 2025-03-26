using Discount;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container
// Application services
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
   config.RegisterServicesFromAssembly(assembly);
   config.AddOpenBehavior(typeof(ValidationBehavior<,>)); // Pipeline MediaR
   config.AddOpenBehavior(typeof(LoggingBehavior<,>)); // Pipeline MediaR Logging
});



// Data services

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
   opts.Connection(builder.Configuration.GetConnectionString("Database")!);
   opts.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
   opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
})
.UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();



// GRPC services

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
{
   // options.Address = new Uri(Environment.GetEnvironmentVariable("GRPC_DISCOUNT_SERVICE_URL")!);
   options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]);
});



// Cross-Cutting Service

builder.Services.AddExceptionHandler<CustomExceptionHandler>();



builder.Services.AddStackExchangeRedisCache(options =>
{
   options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddHealthChecks()
   .AddNpgSql(builder.Configuration.GetConnectionString("Database")!)
   .AddRedis(builder.Configuration.GetConnectionString("Redis")!);

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health", new HealthCheckOptions
{
   ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
