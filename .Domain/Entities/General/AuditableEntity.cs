namespace Collect.Domain.Entities.General;

public class AuditableEntity : BaseEntity
{
	public DateTime Created { get; set; }
}
