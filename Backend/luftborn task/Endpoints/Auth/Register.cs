using Application.Models;
using Application.Service.Abstraction;
using Domain.Entities;
using Domain.Repository;
using FastEndpoints;
using luftborn_task.Endpoints.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace luftborn_task.Endpoints.Auth
{

    public class Register : Endpoint<RegisterRequest, BaseResponse>
    {
        private readonly ILogger<Register> _logger;
        private readonly IAuthService _authService;


        public Register(ILogger<Register> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public override void Configure()
        {
            Post("api/v1/users/register");
            AllowAnonymous();
            DontCatchExceptions();
        }

        public override async Task HandleAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _authService.Register(request);

            _logger.LogInformation($"User Created, ID: {user.Id}");

            await SendAsync(new BaseResponse { StatusCode = StatusCodes.Status200OK, 
                                               Message = "User Created",
                                               IsSuccess = true,
                                              
                                               });
        }
    }
}
