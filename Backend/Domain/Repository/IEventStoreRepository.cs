using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IEventStoreRepository
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(string aggregateId);
    }
}
