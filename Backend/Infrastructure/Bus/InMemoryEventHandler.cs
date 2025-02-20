using Domain.Entities.Base;
using Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Bus
{
    public sealed class InMemoryEventHandler : IEventHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStoreRepository _eventStore;

        public InMemoryEventHandler(IEventStoreRepository eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            var storedEvent = new StoredEvent(@event);
            _eventStore?.Store(storedEvent);

            await _mediator.Publish(@event);
        }

        public async Task<R> SendCommand<T, R>(T command) where T : IRequest<R>
        {

            return await _mediator.Send(command);
        }

        public async Task SendCommand<T>(T command) where T : IRequest
        {

            await _mediator.Send(command);
        }
    }
}
