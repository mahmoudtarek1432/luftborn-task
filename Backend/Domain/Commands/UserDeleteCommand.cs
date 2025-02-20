
using MediatR;

namespace Domain.Commands
{
    public class UserDeleteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public UserDeleteCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
