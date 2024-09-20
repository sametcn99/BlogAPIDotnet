using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAPIDotnet.Dtos.Post;

public class UpdatePostRequestDto
{

        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        public string? Title { get; set; }

        [Required]
        [MinLength(200)]
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Models.Comment>? Comments { get; set; }
}
