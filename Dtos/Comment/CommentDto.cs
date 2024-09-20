using Microsoft.AspNetCore.Mvc;

namespace BlogAPIDotnet.Dtos.Comment
{
    /// <summary>
    /// Represents a comment on a post. Used for returning comment data.
    /// </summary>
    public class CommentDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PostId { get; set; }
    }
}
