using Application.Models;
using Application.Service.Abstraction;
using Ardalis.Specification;
using Domain.Commands;
using Domain.Entities;
using Domain.Events;
using Domain.Repository;
using Infrastructure.Bus;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        public readonly IEventHandler _eventHandler;
        public readonly IRepository<User> _readUserRepo;
        public UserService(IRepository<User> readUserRepo, IEventHandler eventHandler)
        {
            _readUserRepo = readUserRepo;
            _eventHandler = eventHandler;
        }

        public async Task ChangeUserRole(Guid id, string role)
        {
            await _eventHandler.SendCommand(new UserRoleUpdateCommand(id,role));
        }

        public async Task DeleteUser(Guid id)
        {
            await _eventHandler.SendCommand(new UserDeleteCommand(id));
        }

        public async Task<IEnumerable<UserListingDTO>> GetUserList()
        {
            var users = await _readUserRepo.ListAsync();

            if(users == null || !users.Any())
                return Array.Empty<UserListingDTO>();

            return users.Select(u =>
            
                new UserListingDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    Role = u.Role,
                    Name = u.ToString(),
                    Mobile = u.Mobile
                }
            );
        }
    }
}
