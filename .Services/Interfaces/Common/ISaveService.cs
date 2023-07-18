namespace Collect.Services.Interfaces.Common;

public interface ISaveService
{
	public Task<string> SaveAsync(IFormFile file);
}
