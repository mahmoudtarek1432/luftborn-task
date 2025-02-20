using Application.Models;
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

        Task<IEnumerable<UserListingDTO>> GetUserList();

        public Task DeleteUser(Guid id);

        public Task ChangeUserRole(Guid id, string Role);
    }
}
