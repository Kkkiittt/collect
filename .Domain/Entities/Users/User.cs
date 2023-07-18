using Collect.Domain.Entities.Collections;
using Collect.Domain.Entities.General;
using Collect.Domain.Entities.Items;
using Collect.Domain.Entities.Reactions;

using Microsoft.EntityFrameworkCore;

namespace Collect.Domain.Entities.Users;
[Index(nameof(Email), nameof(NickName))]
public class User : AuditableEntity
{
	public string NickName { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string PasswordHash { get; set; } = string.Empty;

	public string Image { get; set; } = string.Empty;

	public bool IsAdmin { get; set; }

	public bool Banned { get; set; }

	public List<Collection> Collections { get; set; } = new List<Collection>();

	public List<Comment> Comments { get; set; } = new List<Comment>();
}
