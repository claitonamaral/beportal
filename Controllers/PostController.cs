using BEPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listPost = await _context.Post.ToListAsync();
                return Ok(listPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var post = await _context.Post.FindAsync(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PostController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            try
            {
                _context.Add(post);
                await _context.SaveChangesAsync();

                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Post post)
        {
            try
            {
                if (id != post.id)
                {
                    return BadRequest();
                }
                _context.Update(post);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Post atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var post = await _context.Post.FindAsync(id);
                if (post == null)
                {
                    return NotFound();
                }

                _context.Post.Remove(post);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Post deletado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
