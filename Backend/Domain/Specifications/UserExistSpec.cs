using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications
{
    public class UserExistSpec : Specification<User>
    {
        public UserExistSpec(string mobile, string email) {
            Query.Where(e => e.Mobile == mobile || e.Email == email)
                 .AsNoTracking();
        }
    }
}
