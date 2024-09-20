using BlogAPIDotnet.Data;
using BlogAPIDotnet.Dtos.Post;
using BlogAPIDotnet.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPIDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        /// <summary>
        /// The BlogContext instance.
        /// </summary>
        private readonly BlogContext _context;

        /// <summary>
        /// Constructor for the PostController class.
        /// </summary>
        /// <param name="context"></param>
        public PostController(BlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stocks = _context.Posts.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePostRequestDto postCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = postCreateDto.ToPostFromCreateDto();
            _context.Posts.Add(post);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"Update post with id {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Delete post with id {id}");
        }
    }
}
