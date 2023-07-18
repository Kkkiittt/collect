using Collect.Services.Interfaces.Common;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Collect.Services.Services.Common;

public class SaveService : ISaveService
{
	private readonly string images = "images";
	private readonly string _rootpath;

	public SaveService(IWebHostEnvironment env)
	{
		_rootpath = env.WebRootPath;
	}

	public async Task<string> SaveAsync(IFormFile file)
	{
		string name = Guid.NewGuid().ToString();

		string path = Path.Combine(_rootpath, images, name);
		FileStream stream = new FileStream(path, FileMode.Create);
		try
		{
			await file.CopyToAsync(stream);
			return Path.Combine(images, name);
		}
		catch
		{
			return "";
		}
		finally
		{
			stream.Close();
		}
	}
}
