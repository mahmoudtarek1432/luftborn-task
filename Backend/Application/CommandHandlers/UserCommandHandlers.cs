using Domain.Entities;
using Domain.Events;
using Domain.Repository;
using MediatR;
using SharedKernel.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class UserCommandHandlers : IRequestHandler<UserDeleteCommand>, IRequestHandler<UserRoleUpdatedCommand>
    {
        private readonly IRepository<User> _userRepository;
        public UserCommandHandlers(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            
            if(user == null)
                throw new BusinessLogicException("User not found");

            user.AddDomainEvent(new UserDeletedEvent(user));

            await _userRepository.DeleteAsync(user);
        }

        public async Task Handle(UserRoleUpdatedCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
                throw new BusinessLogicException("User not found");

            user.SetRole(request.Role);

            user.AddDomainEvent(new UserUpdatedEvent(user));

            await _userRepository.UpdateAsync(user);
        }
    }
}
