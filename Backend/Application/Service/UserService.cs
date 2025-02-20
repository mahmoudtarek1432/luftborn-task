using Application.Service.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        public UserService() { }

        public Task DeactivateUser(Guid id)
        {
            throw new NotImplementedException();

        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
