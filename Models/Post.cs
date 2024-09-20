namespace BlogAPIDotnet.Models;

/// <summary>
/// Represents a comment on a post.
/// </summary>
public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Comment>? Comments { get; set; }
}
