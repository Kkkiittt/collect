using Collect.Domain.Entities.General;
using Collect.Domain.Entities.Items;
using Collect.Domain.Entities.Users;

using Microsoft.EntityFrameworkCore;

namespace Collect.Domain.Entities.Reactions;
[Index(nameof(ItemId), nameof(UserId))]
public class Comment : AuditableEntity
{
	public string Content { get; set; } = string.Empty;

	public long UserId { get; set; }
	public User User { get; set; } = new User();

	public long ItemId { get; set; }
	public Item Item { get; set; } = new Item();
}
