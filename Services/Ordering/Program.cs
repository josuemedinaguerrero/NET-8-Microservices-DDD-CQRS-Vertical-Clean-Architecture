using Ordering.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Ordering.Application.Data;
using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// Infrastructure

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
   options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

// Application

builder.Services.AddMediatR(config =>
{
   config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
   config.AddOpenBehavior(typeof(ValidationBehavior<,>));
   config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

var app = builder.Build();

app.Run();
