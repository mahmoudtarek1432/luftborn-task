using Infrastructure.Data;
using IOC;
using luftborn_task.Extentions;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDatabase>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionStrings().SQLConnection, sql => sql.MigrationsAssembly("Infrastructure"));
});

builder.Services.AddApplicationServices();

builder.Services.AddApplicationRepositories();

var app = builder.Build();

app.Run();
