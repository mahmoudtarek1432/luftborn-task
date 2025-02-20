using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public interface IAuthService
    {
        Task<User> Register(RegisterRequest model);
        Task<(string token, User user)> Login(string email, string password);
    }
}
