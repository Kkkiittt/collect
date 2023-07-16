using Collect.Domain.Entities.General;
using Collect.Domain.Entities.Items;
using Collect.Domain.Entities.Properties;
using Collect.Domain.Entities.Users;

using Microsoft.EntityFrameworkCore;

namespace Collect.Domain.Entities.Collections;

[Index(nameof(Name))]
public class Collection : AuditableEntity
{
	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string Image { get; set; } = string.Empty;

	public List<Property> Properties { get; set; } = new List<Property>();

	public List<Item> Items { get; set; } = new List<Item>();

	public long UserId { get; set; }
	public User User { get; set; } = new User();
}
