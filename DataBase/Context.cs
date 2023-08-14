using Domain.BlogAgg;
using Domain.UserAgg;
using Infrastructure.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class Context:IdentityDbContext
{
    public Context(DbContextOptions<Context> options):base(options)
    {
            
    }
    public DbSet<User> users { get; set; }
    public DbSet<Blog> blogs { get; set; }
    public DbSet<Blog> blog_images { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new BlogMapping());
        builder.ApplyConfiguration(new BlogImageMapping());
        builder.ApplyConfiguration(new UserMapping());
    }
}
