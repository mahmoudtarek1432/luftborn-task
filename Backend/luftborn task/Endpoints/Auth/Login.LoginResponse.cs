using luftborn_task.Endpoints.Model;
using luftborn_task.model;

namespace luftborn_task.Endpoints.Auth
{
    public record class LoginResponse : BaseResponse
    {
        public string Token { get; set; }
        public UserInfoDto UserInfo { get; set; }
    }
}
