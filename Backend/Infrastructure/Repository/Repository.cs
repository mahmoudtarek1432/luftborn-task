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
    public class Repository<T> : RepositoryBase<T>,IRepository<T> where T : class, IAggregateRoot 
    {
        public Repository(ApplicationDatabase db) : base(db)
        {
            
        }
    }
}
