using BlogAPIDotnet.Dtos.Comment;

namespace BlogAPIDotnet.Dtos.Post
{
    /// <summary>
    /// Represents a post. Used for returning post data. 
    /// </summary>
    public class PostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}