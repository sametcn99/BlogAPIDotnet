using BlogAPIDotnet.Dtos.Post;
using BlogAPIDotnet.Models;

namespace BlogAPIDotnet.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post postModel)
        {
            return new PostDto
            {
                Id = postModel.Id,
                Title = postModel.Title,
                Content = postModel.Content,
                CreatedAt = postModel.CreatedAt,
                Comments = postModel.Comments
            };
        }

        public static Post ToPostFromCreateDto(this CreatePostRequestDto postCreateDto)
        {
            return new Post
            {
                Title = postCreateDto.Title,
                Content = postCreateDto.Content
            };

        }
    }
}