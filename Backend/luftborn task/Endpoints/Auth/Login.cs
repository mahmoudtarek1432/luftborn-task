using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Service.Abstraction;
using Domain.Entities;
using Domain.Repository;
using FastEndpoints;
using luftborn_task.model;

namespace luftborn_task.Endpoints.Auth;

public class Login : Endpoint<LoginRequest, LoginResponse>
{
    private readonly ILogger<Register> _logger;
    private readonly IAuthService _authService;

    public Login(ILogger<Register> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }
    public override void Configure()
    {
        Post("api/v1/Auth/Login");
        AllowAnonymous();
        DontCatchExceptions();
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _authService.Login(request.Email, request.Password);

        var response  = new LoginResponse
        {
            IsSuccess = true,
            Message = "Login Successful",
            StatusCode = StatusCodes.Status200OK,
            Token = result.token,
            UserInfo = new UserInfoDto
            {
                Id = result.user.Id,
                FirstName = result.user.FirstName,
                LastName = result.user.LastName,
                Email = result.user.Email,
                Mobile = result.user.Mobile,
                Role = result.user.Role,
                IsActive = result.user.UserVerification.IsActive ?? false
            }
        };

        await SendAsync(response);
    }
}
