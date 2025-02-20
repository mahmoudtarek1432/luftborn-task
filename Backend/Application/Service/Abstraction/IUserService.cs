using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public interface IUserService
    {

        public Task<IEnumerable<User>> GetUserList();

        public Task DeleteUser(Guid id);

        public Task DeactivateUser(Guid id);
    }
}
