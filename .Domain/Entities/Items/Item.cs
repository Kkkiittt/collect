using Collect.Domain.Entities.Collections;
using Collect.Domain.Entities.General;
using Collect.Domain.Entities.Reactions;
using Collect.Domain.Entities.Tags;
using Collect.Domain.Entities.Users;

using Microsoft.EntityFrameworkCore;

namespace Collect.Domain.Entities.Items;
[Index(nameof(CollectionId), nameof(Name))]
public class Item : AuditableEntity
{
	public long CollectionId { get; set; }
	public Collection Collection { get; set; } = new Collection();

	public string Name { get; set; } = string.Empty;

	public List<Tag> Tags { get; set; } = new List<Tag>();

	public List<Comment> Comments { get; set; } = new List<Comment>();

	public string[] Properties { get; set; } = new string[0];
}
