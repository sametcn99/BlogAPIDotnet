using System.ComponentModel.DataAnnotations;

namespace BlogAPIDotnet.Dtos.Post;

/// <summary>
/// Represents a request to create a post.
/// </summary>
public class CreatePostRequestDto
{
    [Required]
    [MinLength(10)]
    public string Title { get; set; } = null!;
    [Required]
    [MinLength(200)]
    public string Content { get; set; } = null!;
}
