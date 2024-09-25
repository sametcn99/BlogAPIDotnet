using BlogAPIDotnet.Dtos.Comment;
using BlogAPIDotnet.Helpers;
using BlogAPIDotnet.Models;

namespace BlogAPIDotnet.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync(QueryObject queryObject);
    Task<Comment> GetByIdAsync(int id);
    Task<Comment> CreateAsync(CreateCommentRequestDto commentCreateDto);
    Task<Comment> UpdateAsync(int id, UpdateCommentRequestDto comment);
    Task<bool> DeleteAsync(int id);
}
