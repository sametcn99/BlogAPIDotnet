using BlogAPIDotnet.Dtos.Post;
using BlogAPIDotnet.Models;

namespace BlogAPIDotnet.Interfaces;

public interface IPostRepository
{
    public Task<List<Post>> GetAllAsync();
    public Task<Post> GetByIdAsync(int id);
    public Task<Post> CreateAsync(CreatePostRequestDto post);
    public Task<Post> UpdateAsync(int id, UpdatePostRequestDto post);
    public Task<bool> DeleteAsync(int id);

}
