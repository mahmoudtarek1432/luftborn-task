namespace luftborn_task.model
{
    public readonly record struct UserInfoDto( Guid Id,
                                               string FirstName,
                                               string LastName,
                                               string Email,
                                               string Mobile,
                                               bool IsActive,
                                               string Role);
   
}
