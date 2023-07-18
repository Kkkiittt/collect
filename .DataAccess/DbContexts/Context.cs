using Collect.Domain.Entities.Collections;
using Collect.Domain.Entities.Items;
using Collect.Domain.Entities.Properties;
using Collect.Domain.Entities.Reactions;
using Collect.Domain.Entities.Tags;
using Collect.Domain.Entities.Users;

using Microsoft.EntityFrameworkCore;

namespace Collect.DataAccess.DbContexts;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> options) : base(options)
	{

	}

	public virtual DbSet<User> Users { get; } = default!;

	public virtual DbSet<Collection> Collections { get; } = default!;

	public virtual DbSet<Item> Items { get; } = default!;

	public virtual DbSet<Property> Properties { get; } = default!;

	public virtual DbSet<Comment> Comments { get; } = default!;

	public virtual DbSet<Like> Like { get; } = default!;

	public virtual DbSet<Tag> Tags { get; } = default!;
}
