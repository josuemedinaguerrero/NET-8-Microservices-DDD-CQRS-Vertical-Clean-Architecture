using Application;
using Infrastructure;
using Ordering;

var builder = WebApplication.CreateBuilder(args);

builder.Services
   .AddApplicationServices()
   .AddInfrastructureServices(builder.Configuration)
   .AddApiServices();

var app = builder.Build();

app.Run();
