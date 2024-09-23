using System.ComponentModel.DataAnnotations;

namespace BlogAPIDotnet.Dtos.Comment;

public class UpdateCommentRequestDto
{
    [Required]
    [MinLength(10, ErrorMessage = "Content must be 10 character."), MaxLength(500, ErrorMessage = "Content must be less than 500 characters.")]
    public string Content { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public int PostId { get; set; }
}