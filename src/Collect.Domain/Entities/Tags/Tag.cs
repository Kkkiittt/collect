using Collect.Domain.Entities.General;
using Collect.Domain.Entities.Items;

using Microsoft.EntityFrameworkCore;

namespace Collect.Domain.Entities.Tags;

[Index(nameof(Name))]
public class Tag : BaseEntity
{
	public string Name { get; set; } = string.Empty;

	public List<Item> Items { get; set; } = new List<Item>();
}
