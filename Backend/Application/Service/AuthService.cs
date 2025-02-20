using Application.Models;
using Application.Service.Abstraction;
using Domain.Entities;
using Domain.Repository;
using Domain.Specifications;
using SharedKernel.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Service
{
    public class AuthService : IAuthService
    {
        public IRepository<User> _userRepository;
        public ITokenClaimsService _tokenService;
        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Register(RegisterRequest model)
        {
            var mobileSpec = new UserMobileExistSpec(model.Mobile);
            var mobileExist = await _userRepository.AnyAsync(mobileSpec);

            if(mobileExist)
                throw new BusinessLogicException("Mobile number already exist");

            var user = new User(model.FirstName, model.LastName, model.Email, model.Password)
                            .ValidateFirstName(model.FirstName)
                            .ValidateLastName(model.LastName)
                            .ValidateEmail(model.Email)
                            .ValidateMobile(model.Mobile)
                            .SetMobile(model.Mobile)
                            .SetUserVerification(new UserVerification(isActive: true));

            var savedUser = await _userRepository.AddAsync(user);
            return savedUser;
        }

        public async Task<(string token, User user)> Login(string email, string password)
        {
            var emailSpec = new UsersFilterByEmailSpec(email);
            
            var user = await _userRepository.FirstOrDefaultAsync<User>(emailSpec);

            if (user == null)
                throw new BusinessLogicException("User not found");

            user.ValidateLogin(password);

            var token = _tokenService.GetTokenAsync(user.TokenAuthInfo());

            return (token, user);
        }
    }
}
