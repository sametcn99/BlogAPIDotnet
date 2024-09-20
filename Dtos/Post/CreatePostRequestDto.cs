using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAPIDotnet.Dtos.Post;

public class CreatePostRequestDto
{
    [Required]
    [MinLength(10)]
    public string Title { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
}
