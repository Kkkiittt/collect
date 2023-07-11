using Collect.Domain.Entities.Items;
using Collect.Domain.Entities.Users;

namespace Collect.Domain.Entities.Reactions;

public class Like
{
	public long UserId { get; set; }
	public User User { get; set; } = new User();

	public long ItemId { get; set; }
	public Item Item { get; set; } = new Item();
}
