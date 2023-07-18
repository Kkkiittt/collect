using System.ComponentModel.DataAnnotations;

namespace Collect.Services.Dtos.Users;

public class LoginDto
{
	[EmailAddress, Required]
	public string Email { get; set; } = string.Empty;

	[Required, MinLength(2)]
	public string Password { get; set; } = string.Empty;
}
