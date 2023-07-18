using System.ComponentModel.DataAnnotations;

namespace Collect.Services.Dtos.Users;

public class RegisterDto
{
	[MinLength(3), MaxLength(30), Required]
	public string NickName { get; set; } = string.Empty;

	[EmailAddress, Required]
	public string Email { get; set; } = string.Empty;
}
