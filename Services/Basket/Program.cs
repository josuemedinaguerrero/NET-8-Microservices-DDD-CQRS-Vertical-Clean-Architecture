var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
   config.RegisterServicesFromAssembly(assembly);
   config.AddOpenBehavior(typeof(ValidationBehavior<,>)); // Pipeline MediaR
   config.AddOpenBehavior(typeof(LoggingBehavior<,>)); // Pipeline MediaR Logging
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
   opts.Connection(builder.Configuration.GetConnectionString("Database")!);
   opts.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
   opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
})
.UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();

builder.Services.AddStackExchangeRedisCache(options =>
{
   options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
