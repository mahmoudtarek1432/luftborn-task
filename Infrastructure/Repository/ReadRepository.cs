using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Repository;
using Infrastructure.Data;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    class ReadRepository<T> : RepositoryBase<T>,IRepository<T> where T : class, IAggregateRoot 
    {
        public ReadRepository(ApplicationDatabase db) : base(db)
        {

        }
    }
}
