using Collect.Services.Dtos.Users;
using Collect.Services.ViewModels;

namespace Collect.Services.Interfaces;

public interface IUserService
{
	public Task<bool> RegisterAsync(RegisterDto dto);

	public Task<bool> UpdateAsync(UpdateDto dto);

	public Task<bool> DeleteAsync();

	public Task<bool> ResetPasswordAsync(string email);

	public Task<UserFullViewModel> GetAsync(string email);

	public Task<UserFullViewModel> GetAsync(long id);

	public Task<bool> PromoteAsync(long id);

	public Task<bool> DemoteAsync(long id);

	public Task<bool> BanAsync(long id);

	public Task<bool> UnbanAsync(long id);

	public Task<bool> DeleteAsync(long id);
}
