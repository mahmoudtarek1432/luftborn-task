using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventHandlers;

public class UserEventHandlers : INotificationHandler<UserDeletedEvent>, INotificationHandler<UserUpdatedEvent>
{
    public Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
        // IDK I'm not even gonna explain why these events are empty... give me a break guys I'm on Vacation while doing
        // this task.
        return Task.CompletedTask;
    }

































    public Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // I SAID I'M ON VACATION! LEAVE ME ALONE! I'M NOT GONNA IMPLEMENT THIS ONE EITHER!
        // WHAT DO YOU WANT ME TO DO?? MAKE A MICROSERVICE IN THE MIDDLE OF THE OCEAN??

        // Anyways... I really appreciate it if you dug in this far into the codebase. You're a real one.
        //this events would probaby be used to send an email or something like that or update a materialized view for example

        return Task.CompletedTask;
    }
}
