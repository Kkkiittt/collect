using System.ComponentModel.DataAnnotations;

namespace Collect.Services.Dtos.Users;

public class UpdateDto : RegisterDto
{
	[Required, MinLength(1), MaxLength(16)]
	public string Password { get; set; } = string.Empty;

	[FileExtensions(Extensions = "*.png, *.jpg")]
	public IFormFile? Image { get; set; }
}
