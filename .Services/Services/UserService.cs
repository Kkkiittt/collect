using Collect.DataAccess.DbContexts;
using Collect.Domain.Entities.Users;
using Collect.Services.Dtos.Users;
using Collect.Services.Interfaces;
using Collect.Services.Interfaces.Common;
using Collect.Services.Security;
using Collect.Services.Services.Common;
using Collect.Services.Utils;
using Collect.Services.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace Collect.Services.Services;

public class UserService : IUserService
{
	private Context _db { get; }
	private IEmailService _email { get; }
	private ISaveService _save { get; }

	private async Task<User> FindCheck(long id)
	{
		User? entity = await _db.Users.FindAsync(id);
		if(entity is null)
			throw new CodeException("User with this ID not found", System.Net.HttpStatusCode.NotFound);
		return entity;
	}

	private async Task<User> FindCheck(string email)
	{
		User? entity = await _db.Users.FirstOrDefaultAsync(usr => usr.Email == email);
		if(entity is null)
			throw new CodeException("User with this email not found", System.Net.HttpStatusCode.NotFound);
		return entity;
	}

	private async Task<bool> SetBanAsync(long id, bool banned)
	{
		User entity = await FindCheck(id);
		entity.Banned = banned;
		_db.Update(entity);
		return await _db.SaveChangesAsync() > 0;
	}

	public async Task<bool> BanAsync(long id)
	{
		return await SetBanAsync(id, true);
	}

	public Task<bool> DeleteAsync()
	{
		throw new NotImplementedException();
	}

	public async Task<bool> DeleteAsync(long id)
	{
		User entity = await FindCheck(id);
		_db.Users.Remove(entity);
		return await _db.SaveChangesAsync() > 0;
	}

	private async Task<bool> SetMoteAsync(long id, bool mote)
	{
		User entity = await FindCheck(id);
		entity.IsAdmin = mote;
		return await _db.SaveChangesAsync() > 0;
	}

	public async Task<bool> DemoteAsync(long id)
	{
		return await SetMoteAsync(id, false);
	}

	public async Task<UserFullViewModel> GetAsync(string email)
	{
		User entity = await FindCheck(email);
		return new UserFullViewModel()
		{
			Id = entity.Id,
			Email = entity.Email,
			Image = entity.Image,
			NickName = entity.NickName
		};
	}

	public async Task<UserFullViewModel> GetAsync(long id)
	{
		User entity = await FindCheck(id);
		return new UserFullViewModel()
		{
			Id = entity.Id,
			Email = entity.Email,
			Image = entity.Image,
			NickName = entity.NickName
		};
	}

	public async Task<bool> PromoteAsync(long id)
	{
		return await SetMoteAsync(id, true);
	}

	public async Task<bool> RegisterAsync(RegisterDto dto)
	{
		string password = Guid.NewGuid().ToString().Substring(0, 8);
		await _email.SendAsync(dto.Email, "Password for Collect",
			$"Your password is <h2>{password}</h2>\n You can use it for logging in and then change it."
			);
		User entity = new User()
		{
			Email = dto.Email,
			Created = DateTime.Now,
			NickName = dto.NickName,
			PasswordHash = Hasher.Hash(password),
		};
		_db.Users.Add(entity);
		return await _db.SaveChangesAsync() > 0;
	}

	public async Task<bool> ResetPasswordAsync(string email)
	{
		User entity = await FindCheck(email);
		string password = Guid.NewGuid().ToString().Substring(0, 8);
		await _email.SendAsync(entity.Email, "Password for Collect",
			$"Your password is <h2>{password}</h2>\n You can use it for logging in and then change it."
			);
		entity.PasswordHash = Hasher.Hash(password);
		return await _db.SaveChangesAsync() > 0;
	}

	public async Task<bool> UnbanAsync(long id)
	{
		return await SetBanAsync(id, false);
	}

	public async Task<bool> UpdateAsync(UpdateDto dto)
	{
		User entity = new User()
		{
			Email = dto.Email,
			Image = dto.Image is null ? "" : await _save.SaveAsync(dto.Image),
			NickName = dto.NickName,
			PasswordHash = Hasher.Hash(dto.Password),
		};
		_db.Users.Update(entity);
		return await _db.SaveChangesAsync() > 0;
	}
}
