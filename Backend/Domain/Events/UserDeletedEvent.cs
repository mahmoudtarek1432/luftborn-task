using Domain.Entities;
using MediatR;
using SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class UserDeletedEvent : Event
    {
        public User DeletedUser { get; set; }
        public UserDeletedEvent(User user)
        {
            DeletedUser = user;
        }
    }
}
