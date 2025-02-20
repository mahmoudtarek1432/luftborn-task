using Ardalis.Specification;
using Domain.Repository;
using Infrastructure.Bus;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class ApplicationRepositories
    {
        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));

            services.AddScoped<IEventStoreRepository, EventStoreMongoRepository>();

            services.AddScoped<IEventHandler, InMemoryEventHandler>();
        }
    }
}
