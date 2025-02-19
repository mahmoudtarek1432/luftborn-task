using IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();

builder.Services.AddApplicationRepositories();

var app = builder.Build();

app.Run();
