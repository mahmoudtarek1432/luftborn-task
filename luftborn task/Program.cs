using Infrastructure.Data;
using IOC;
using luftborn_task.Extentions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using FastEndpoints.Security;
using FastEndpoints;
using SharedKernel.Constants;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDatabase>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionStrings().SQLConnection, sql => sql.MigrationsAssembly("Infrastructure"));
});

builder.Services.AddApplicationServices();

builder.Services.AddApplicationRepositories();


//builder.Services.AddAuthorization(cfg =>
//{
//    cfg.AddPolicy(nameof(RoleConstants.ADMIN), policy => policy.RequireRole(nameof(RoleConstants.ADMIN)));
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AuthConstants.CORS_POLICY,
                builder =>
                {
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    //TODO: need to change this.
                    builder.AllowAnyOrigin();
                });
});


builder.Services.AddAuthenticationJwtBearer(s => s.SigningKey = AuthConstants.JWT_SECRET_KEY)
    .AddAuthorization()
    .AddFastEndpoints();



var app = builder.Build();

app.UseHttpsRedirection();


app.UseRouting();

app.UseCors(AuthConstants.CORS_POLICY);
app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();

app.Run();
