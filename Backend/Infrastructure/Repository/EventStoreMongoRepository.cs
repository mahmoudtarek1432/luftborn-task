using Domain.Entities.Base;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EventStoreMongoRepository : IEventStoreRepository
    {
        private readonly EventStoreDatabase _ctx;
        private readonly ILogger<EventStoreMongoRepository> _logger;
        public EventStoreMongoRepository(ILogger<EventStoreMongoRepository> logger)
        {
            _ctx = new EventStoreDatabase();
            _logger = logger;
        }

        public async Task<IList<StoredEvent>> All(string aggregateId)
        {
            return await _ctx.EventStoreDBSet.AsQueryable().Where(es => es.AggregateID == aggregateId).ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Store(StoredEvent theEvent)
        {
            try
            {
                _ctx.EventStoreDBSet?.InsertOne(theEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error, event store is not setup properly");
            }
        }
    }
}
