using Microsoft.EntityFrameworkCore;

using BlogAPIDotnet.Data;
using BlogAPIDotnet.Dtos.Post;
using BlogAPIDotnet.Interfaces;
using BlogAPIDotnet.Models;
using BlogAPIDotnet.Helpers;

namespace BlogAPIDotnet.Repository;

public class PostRepository(BlogContext context) : IPostRepository
{
    private readonly BlogContext _context = context;

    public async Task<List<Post>> GetAllAsync(QueryObject queryObject)
    {
        var posts = _context.Posts.AsQueryable();
        if (queryObject.IsDesc != null)
        {
            posts = posts.OrderByDescending(p => p.CreatedAt);
        }
        var skipNumber = (queryObject.Page - 1) * queryObject.PageSize;
        posts = posts.Skip(skipNumber).Take(queryObject.PageSize);
        return await posts.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        var post = await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
        if (post == null)
        {
            throw new KeyNotFoundException($"Post with Id {id} not found.");
        }
        return post;
    }

    public async Task<Post> UpdateAsync(int id, UpdatePostRequestDto post)
    {
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (existingPost == null)
        {
            throw new KeyNotFoundException($"Post with Id {id} not found.");
        }

        existingPost.Title = post.Title;
        existingPost.Content = post.Content;
        _context.Posts.Update(existingPost);
        await _context.SaveChangesAsync();
        return existingPost;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post == null)
        {
            return false;
        }
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Post> CreateAsync(CreatePostRequestDto post)
    {
        var newPost = new Post
        {
            Title = post.Title,
            Content = post.Content,
            CreatedAt = DateTime.Now

        };

        _context.Posts.Add(newPost);
        await _context.SaveChangesAsync();
        return newPost;
    }
}