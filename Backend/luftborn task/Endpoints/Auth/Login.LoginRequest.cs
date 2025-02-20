namespace luftborn_task.Endpoints.Auth
{
    public record struct LoginRequest
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
