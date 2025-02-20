using Application.Service.Abstraction;
using luftborn_task.model;
using Microsoft.AspNetCore.Mvc;

namespace luftborn_task.Controllers
{
    [ApiController]
    public class UserController(IUserService _userService) : ControllerBase
    {
        [HttpGet("api/v1/users")]
        public async Task<IActionResult> GetUserList()
        {
            var users = await _userService.GetUserList();
            return Ok(new UserListResponse
            {
                IsSuccess = true,
                Users = users.ToList()
            });
        }

        [HttpDelete("api/v1/user/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUser(id);
            return Ok(new UserListResponse
            {
                IsSuccess = true,
                Message = "User Deleted"
            });
        }

        [HttpPut("api/v1/user/{id}/Role/{role}")]
        public async Task<IActionResult> UpdateUserRole(Guid id, string role)
        {
            await _userService.ChangeUserRole(id, role);
            return Ok(new UserListResponse
            {
                IsSuccess = true,
                Message = "User Role Updated"
            });
        }
    }
}
