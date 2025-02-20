using Domain.Entities;
using Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class UserDeleteCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
    
    public class UserRoleUpdatedCommand : IRequest
    {
        public Guid UserId { get; set; }

        public string Role { get; set; }
    }
}
