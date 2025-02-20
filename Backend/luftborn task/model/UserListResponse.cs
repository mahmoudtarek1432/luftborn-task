using Application.Models;
using luftborn_task.Endpoints.Model;

namespace luftborn_task.model
{
    public record class UserListResponse : BaseResponse
    {
        public List<UserListingDTO> Users { get; set; }
    }
}
