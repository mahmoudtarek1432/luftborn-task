using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Event
{
    public class Event : INotification
    {
        public string AggregateID { get; set; }
        public DateTime TimeStamp { get; protected set; } = DateTime.UtcNow;
    }
}
