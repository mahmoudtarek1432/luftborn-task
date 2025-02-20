using Domain.Entities.Base;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        EventStoreDatabase _ctx;
        public EventStoreMongoRepository()
        {
            _ctx = new EventStoreDatabase();
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
            _ctx.EventStoreDBSet?.InsertOne(theEvent);
        }
    }
}
