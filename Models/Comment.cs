namespace BlogAPIDotnet.Models;

/// <summary>
/// Represents a comment on a post.
/// </summary>
public class Comment
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int PostId { get; set; }
}
