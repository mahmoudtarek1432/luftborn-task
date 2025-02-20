using Domain.Entities.Base;
using Infrastructure.Bus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extentions
{
    public static class MeditrExtentions
    {
        public static async Task PublishDomainEvents<T>(this IEventHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<EntityBase>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            await Task.WhenAll( domainEvents.Select(async (domainEvent) => {
                                                await mediator.PublishEvent(domainEvent);
                                            })
            );
        }
    }
}
