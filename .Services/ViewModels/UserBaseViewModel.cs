using Collect.Domain.Entities.General;

namespace Collect.Services.ViewModels;

public class UserBaseViewModel : BaseEntity
{
	public string NickName { get; set; } = string.Empty;

	public string Image { get; set; } = string.Empty;
}
