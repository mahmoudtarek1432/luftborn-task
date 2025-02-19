using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public record struct RegisterRequest (
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Mobile);

    //HOLA~!, if you are looking at this code, here is a tip for you,
    //a record struct is waaaaaay faster than a record class as it is stored in stack and so on.
    //but keep in mind, the struct is mutable by default, so add a readonly modifier

}


