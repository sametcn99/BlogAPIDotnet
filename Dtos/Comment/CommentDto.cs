using Microsoft.AspNetCore.Mvc;

namespace BlogAPIDotnet.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PostId { get; set; }
    }
}
