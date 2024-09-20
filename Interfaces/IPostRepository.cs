using System;
using BlogAPIDotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogAPIDotnet.Dtos.Post;

namespace BlogAPIDotnet.Interfaces;

public interface IPostRepository
{
    public Task<List<Post>> GetAllAsync();
    public Task<Post> GetByIdAsync(int id);
    public Task<Post> CreateAsync(Post post);
    public Task<Post> UpdateAsync(int id, UpdatePostRequestDto post);
    public Task<bool> DeleteAsync(int id);

}
