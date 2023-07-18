using System.Net;

namespace Collect.Services.Utils;

public class CodeException : Exception
{
	public CodeException(string message, HttpStatusCode code) : base(message)
	{
		Code = code;
	}

	public HttpStatusCode Code { get; set; }
}
