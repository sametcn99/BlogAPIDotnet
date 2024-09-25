using Microsoft.EntityFrameworkCore;

using BlogAPIDotnet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlogAPIDotnet.Migrations;
using Microsoft.AspNetCore.Identity;

namespace BlogAPIDotnet.Data;

public class BlogContext : IdentityDbContext<AppUser>
{
    /// <summary>
    /// Constructor for the BlogContext class.
    /// </summary>
    /// <param name="options"></param>
    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "User", NormalizedName = "USER" }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}
