namespace Collect.Services.Security;

public static class Hasher
{
	public static string Hash(string input)
	{
		return BCrypt.Net.BCrypt.HashPassword(input);
	}

	public static bool Check(string hash, string input)
	{
		return BCrypt.Net.BCrypt.Verify(input, hash);
	}
}
