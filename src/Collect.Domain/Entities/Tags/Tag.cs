using Collect.Domain.Entities.General;
using Collect.Domain.Entities.Items;

namespace Collect.Domain.Entities.Tags;

public class Tag : BaseEntity
{
	public string Content { get; set; } = string.Empty;

	public List<Item> Items { get; set; } = new List<Item>();
}
