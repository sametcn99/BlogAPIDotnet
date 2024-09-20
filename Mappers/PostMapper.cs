using BlogAPIDotnet.Dtos.Post;
using BlogAPIDotnet.Models;

namespace BlogAPIDotnet.Mappers
{
    /// <summary>
    /// Maps between Post models and Post DTOs.
    /// </summary>
    public static class PostMapper
    {
        /// <summary>
        /// Maps a Post model to a Post DTO.
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Maps a CreatePostRequestDto to a Post model.
        /// </summary>
        /// <param name="postCreateDto"></param>
        /// <returns></returns>
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