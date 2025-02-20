using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications
{
    public class UsersFilterByEmailSpec : Specification<User, User>, ISingleResultSpecification<User>
    {
        public UsersFilterByEmailSpec(string email)
        {
            Query
                .Where(x => x.Email == email)
                ;
        }
    }
}
