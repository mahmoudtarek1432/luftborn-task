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
    public class UserUpdatedEvent : Event
    {
        public User _user { get; set; }
        public UserUpdatedEvent(User user)
        {
            _user = user;
        }
    }
}
