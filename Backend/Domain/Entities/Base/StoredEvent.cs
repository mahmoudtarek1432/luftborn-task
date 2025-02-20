using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SharedKernel.Event;

namespace Domain.Entities.Base
{
    public class StoredEvent : Event
    {
        public string Data { get; set; }
        public string EventType { get; set; }
        public StoredEvent(Event @event)
        {
            Data = System.Text.Json.JsonSerializer.Serialize(@event);
            EventType = @event.GetType().Name;
            AggregateID = @event.AggregateID;
        }
    }
}
