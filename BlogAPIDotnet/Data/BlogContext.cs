using Microsoft.EntityFrameworkCore;

using BlogAPIDotnet.Models;

namespace BlogAPIDotnet.Data;

public class BlogContext : DbContext
{
    /// <summary>
    /// Constructor for the BlogContext class.
    /// </summary>
    /// <param name="options"></param>
    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
