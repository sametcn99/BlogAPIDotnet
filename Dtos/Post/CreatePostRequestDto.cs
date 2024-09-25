using System.ComponentModel.DataAnnotations;

namespace BlogAPIDotnet.Dtos.Post;

/// <summary>
/// Represents a request to create a post.
/// </summary>
public class CreatePostRequestDto
{
    [Required]
    [MinLength(10, ErrorMessage = "Title must be 10 character."), MaxLength(100, ErrorMessage = "Title must be less than 100 characters.")]
    public string Title { get; set; } = null!;
    [Required]
    [MinLength(10, ErrorMessage = "Content must be 10 character."), MaxLength(500, ErrorMessage = "Content must be less than 500 characters.")]
    public string Content { get; set; } = null!;
}
