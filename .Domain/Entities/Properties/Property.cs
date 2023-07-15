using Collect.Domain.Entities.General;

namespace Collect.Domain.Entities.Properties;

public class Property : BaseEntity
{
	public Type Type { get; set; }

	public string Name { get; set; } = string.Empty;
}
