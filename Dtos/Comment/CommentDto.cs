namespace BlogAPIDotnet.Dtos.Comment
{
    /// <summary>
    /// Represents a comment on a post. Used for returning comment data.
    /// </summary>
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? PostId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
