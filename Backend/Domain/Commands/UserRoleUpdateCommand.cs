using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class UserRoleUpdateCommand : IRequest
    {
        public Guid UserId { get; set; }

        public string Role { get; set; }

        public UserRoleUpdateCommand(Guid userId, string role)
        {
            UserId = userId;
            Role = role;
        }
    }
}
