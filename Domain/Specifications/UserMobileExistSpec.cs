using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications
{
    public class UserMobileExistSpec : Specification<User>
    {
        public UserMobileExistSpec(string mobile) {
            Query.Where(e => e.Mobile == mobile)
                 .AsNoTracking();
        }
    }
}
