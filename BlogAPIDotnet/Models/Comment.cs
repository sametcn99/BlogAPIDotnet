namespace BlogAPIDotnet.Models;

/// <summary>
/// Represents a comment on a post.
/// </summary>
public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public int PostId { get; set; }
}
