using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Models;
using MyBlogBLL.Services;
using MyBlogBLL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        // GET: api/<BlogsController>
        [HttpGet]
        public ActionResult<IEnumerable<BlogModel>> GetAll()
        {
            return Ok(_blogService.GetAll());
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogModel>> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);

            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        // POST api/<BlogsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BlogModel>> Add([FromBody] BlogModel blogModel)
        {
            try
            {
                await _blogService.AddAsync(blogModel);
                return Ok();
            }
            catch (BlogException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<BlogModel> Update(int id, [FromBody] BlogModel blogModel)
        {
            try
            {
                _blogService.Update(blogModel);
                return Ok();
            }
            catch (BlogException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _blogService.DeleteByIdAsync(id);

            if (result)
                return Ok();

            return NotFound();
        }

        [HttpGet]
        [Route("{id}/articles")]
        public async Task<ActionResult<IEnumerable<ArticleModel>>> GetArticlesByBlogId(int id)
        {
            var articles = await _blogService.GetArticlesByBlogId(id);

            if (articles == null)
                return NotFound();

            return Ok(articles);
        }
    }
}
