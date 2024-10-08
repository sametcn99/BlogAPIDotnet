using Microsoft.AspNetCore.Mvc;

using BlogAPIDotnet.Data;
using BlogAPIDotnet.Dtos.Post;
using BlogAPIDotnet.Interfaces;
using BlogAPIDotnet.Mappers;
using BlogAPIDotnet.Helpers;

namespace BlogAPIDotnet.Controllers
{
    [Route("api/[controller]")] // dynamically bind the route to the controller name
    [ApiController]
    public class PostController : ControllerBase
    {
        /// <summary>
        /// The BlogContext instance.
        /// </summary>
        private readonly BlogContext _context;

        private readonly IPostRepository _postRepository;

        /// <summary>
        /// Constructor for the PostController class.
        /// </summary>
        /// <param name="context"></param>
        public PostController(BlogContext context, IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryObject queryObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var posts = await _postRepository.GetAllAsync(queryObject);
            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var post = postCreateDto.ToPostFromCreateDto();
            var createdPost = await _postRepository.CreateAsync(postCreateDto);

            return CreatedAtAction(nameof(Get), new { id = createdPost.Id }, createdPost);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePostRequestDto postUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await _postRepository.UpdateAsync(id, postUpdateDto);
            if (post == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var post = await _postRepository.DeleteAsync(id);
            if (!post)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
