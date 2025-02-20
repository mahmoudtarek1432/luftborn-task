using MediatR;
using SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Bus
{
    public interface IEventHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task SendCommand<T>(T command) where T : IRequest;
        Task<R> SendCommand<T,R>(T command) where T : IRequest<R>;

    }
}
