using Domain.Entities.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EventStoreDatabase
    {
        MongoClient mongoClient;
        public IMongoCollection<StoredEvent> EventStoreDBSet;
        public EventStoreDatabase()
        {
            var connectionString = Environment.GetEnvironmentVariable("mongodb://localhost:27017");
            if (connectionString != null)
            {
                mongoClient = new MongoClient(connectionString);
                var EventStoredb = mongoClient.GetDatabase("EventStoreDB");
                EventStoreDBSet = EventStoredb.GetCollection<StoredEvent>("StoredEvent");
            }
        }
    }
}
