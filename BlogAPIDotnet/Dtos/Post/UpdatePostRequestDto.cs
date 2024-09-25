using System.ComponentModel.DataAnnotations;

namespace BlogAPIDotnet.Dtos.Post;

public class UpdatePostRequestDto
{
    public int Id { get; set; }
    [Required]
    [MinLength(10, ErrorMessage = "Title must be 10 character."), MaxLength(100, ErrorMessage = "Title must be less than 100 characters.")]
    public string? Title { get; set; }
    [Required]
    [MinLength(10, ErrorMessage = "Content must be 10 character."), MaxLength(500, ErrorMessage = "Content must be less than 500 characters.")]
    public string? Content { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    public List<Models.Comment>? Comments { get; set; }
}
