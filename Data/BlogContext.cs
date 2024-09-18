using System;
using Microsoft.EntityFrameworkCore;
using BlogAPIDotnet.Models;
namespace BlogAPIDotnet.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
