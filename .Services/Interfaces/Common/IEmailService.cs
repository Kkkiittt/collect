namespace Collect.Services.Interfaces.Common;

public interface IEmailService
{
	public Task<bool> SendAsync(string email, string subject, string body);
}
