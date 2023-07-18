using System.Net;
using System.Net.Mail;

namespace Collect.Services.Services.Common;

public class EmailService
{
	private readonly IConfiguration _config;

	public EmailService(IConfiguration config)
	{
		_config = config.GetSection("Email");
	}

	public async Task<bool> SendAsync(string email, string subject, string body)
	{
		MailAddress from = new MailAddress(_config["email"], _config["name"]);
		MailAddress to = new MailAddress(email);
		MailMessage message = new MailMessage(from, to);
		message.Subject = subject;
		message.Body = body;
		message.IsBodyHtml = true;
		SmtpClient smtpClient = new SmtpClient(_config["host"], int.Parse(_config["port"]));
		smtpClient.EnableSsl = true;
		smtpClient.Credentials = new NetworkCredential(_config["email"], _config["password"]);
		await smtpClient.SendMailAsync(message);
		return true;
	}
}
