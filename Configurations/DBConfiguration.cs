using Collect.DataAccess.DbContexts;

using Microsoft.EntityFrameworkCore;

namespace Collect.Configurations;

public static class DBConfiguration
{
	public static void ConfigureDb(this WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<Context>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("RailwayPostgres")));
	}
}
