using Microsoft.AspNetCore.Mvc;

namespace BlogAPIDotnet.Controllers
{
    [Route("api/[controller]")] // dynamically bind the route to the controller name
    [ApiController]
    public class CommentController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get all comments");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Get comment with id {id}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Create a new comment");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"Update comment with id {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Delete comment with id {id}");
        }
    }
}
