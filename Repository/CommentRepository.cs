using Microsoft.EntityFrameworkCore;

using BlogAPIDotnet.Data;
using BlogAPIDotnet.Dtos.Comment;
using BlogAPIDotnet.Interfaces;
using BlogAPIDotnet.Models;
using BlogAPIDotnet.Helpers;

namespace BlogAPIDotnet.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly BlogContext _context;

    public CommentRepository(BlogContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> GetAllAsync(QueryObject queryObject)
    {
        var comments = _context.Comments.AsQueryable();
        if (!string.IsNullOrWhiteSpace(queryObject.CreatedBy))
        {
            comments = comments.Where(c => c.CreatedBy == queryObject.CreatedBy);
        }
        return await comments.ToListAsync();
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            throw new KeyNotFoundException($"Comment with Id {id} not found.");
        }
        return comment;
    }

    public async Task<Comment> CreateAsync(CreateCommentRequestDto commentCreateDto)
    {
        if (string.IsNullOrWhiteSpace(commentCreateDto.Content))
        {
            throw new ArgumentException("Content cannot be empty.", nameof(commentCreateDto.Content));
        }

        if (string.IsNullOrWhiteSpace(commentCreateDto.CreatedBy))
        {
            throw new ArgumentException("CreatedBy cannot be empty.", nameof(commentCreateDto.CreatedBy));
        }

        var newComment = new Comment
        {
            Content = commentCreateDto.Content,
            CreatedBy = commentCreateDto.CreatedBy,
            PostId = commentCreateDto.PostId,
            CreatedAt = DateTime.Now
        };

        _context.Comments.Add(newComment);
        await _context.SaveChangesAsync();
        return newComment;
    }

    public async Task<Comment> UpdateAsync(int id, UpdateCommentRequestDto commentDto)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (existingComment == null)
        {
            throw new KeyNotFoundException($"Comment with Id {id} not found.");
        }

        var postExists = await _context.Posts.AnyAsync(p => p.Id == commentDto.PostId);
        if (!postExists)
        {
            throw new ArgumentException($"Post with Id {commentDto.PostId} does not exist.");
        }

        existingComment.Content = commentDto.Content ?? string.Empty;
        existingComment.CreatedBy = commentDto.CreatedBy ?? string.Empty;
        existingComment.PostId = commentDto.PostId;

        _context.Comments.Update(existingComment);
        await _context.SaveChangesAsync();
        return existingComment;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment == null)
        {
            return false;
        }
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }
}