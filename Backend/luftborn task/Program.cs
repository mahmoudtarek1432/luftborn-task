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
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;


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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ksa.Einvoice.Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.<br /> 
               Enter 'Bearer' [space] and then your token in the text input below.<br />
               Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

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

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(ApplicationDatabase).Assembly);
});

builder.Services.AddControllers();
builder.Services.AddAuthenticationJwtBearer(s => s.SigningKey = AuthConstants.JWT_SECRET_KEY)
    .AddAuthorization()
    .AddFastEndpoints();



var app = builder.Build();

app.UseHttpsRedirection();


app.UseRouting();

if (builder.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ksa.Einvoice.Api v1"));
}

app.UseCors(AuthConstants.CORS_POLICY);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCustomExceptionHandler()
    .UseFastEndpoints();

app.Run();
