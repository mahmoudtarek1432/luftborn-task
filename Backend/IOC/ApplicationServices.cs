using Application.EventHandlers;
using Application.Service;
using Application.Service.Abstraction;
using Domain.Commands;
using Domain.Commands.Handlers;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

            //command handlers
            services.AddScoped<IRequestHandler<UserDeleteCommand>, UserCommandHandlers>();
            services.AddScoped<IRequestHandler<UserRoleUpdatedCommand>, UserCommandHandlers>();

            //event handlers
            services.AddScoped<INotificationHandler<UserDeletedEvent>, UserEventHandlers>();
            services.AddScoped<INotificationHandler<UserUpdatedEvent>, UserEventHandlers>();
        }
    }
}
