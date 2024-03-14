using System.ComponentModel.DataAnnotations;

namespace Sagicor.Access.Application.Models.Identity;

public class RegistrationRequest
{

    public string FirstName { get; set; }


    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }


    public string UserName { get; set; }

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string[]? Roles { get; set; } = null;
}
