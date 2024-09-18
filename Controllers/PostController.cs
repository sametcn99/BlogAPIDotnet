using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPIDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get all posts");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Get post with id {id}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Create a new post");
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
