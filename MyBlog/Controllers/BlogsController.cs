using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.ViewModels;
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
    /// <summary>
    /// Controller for blog service
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        /// <summary>
        /// Blog controller constructor
        /// </summary>
        /// <param name="blogService">Implementation of blogService</param>
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// Gets all blogs
        /// </summary>
        /// <returns>IEnumerable of BlogModel</returns>
        // GET: api/<BlogsController>
        [HttpGet]
        public ActionResult<IEnumerable<BlogModel>> GetAll()
        {
            return Ok(_blogService.GetAll());
        }

        /// <summary>
        /// Gets blog by id
        /// </summary>
        /// <param name="id">Blog id</param>
        /// <returns>BlogModel or NotFound if blog with such id doesn't exist</returns>
        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogModel>> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);

            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        /// <summary>
        /// Creates new blog
        /// </summary>
        /// <param name="blogModel">BlogModel to create in DB</param>
        /// <returns>OK if successful, BadRequest if not</returns>
        // POST api/<BlogsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BlogModel>> Add([FromBody] BlogViewModel blogModel)
        {
            try
            {
                var model = new BlogModel
                {
                    Name = blogModel.Name,
                    Description = blogModel.Description,
                    CreatorId = HttpContext.User.Identity.Name
                };
                await _blogService.AddAsync(model);
                return Ok(model);
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

        /// <summary>
        /// Updates blog
        /// </summary>
        /// <param name="id">Blog id</param>
        /// <param name="blogModel">BlogModel to update</param>
        /// <returns>OK if successful, BadRequest if not</returns>
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

        /// <summary>
        /// Deletes blog from DB
        /// </summary>
        /// <param name="id">Blog id</param>
        /// <returns>OK is successful, NotFound if blog with such id doesn't exist in DB</returns>
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

        /// <summary>
        /// Gets all articles of certain blog
        /// </summary>
        /// <param name="id">Blog id</param>
        /// <returns>IEnumerable of ArticleModel or NotFound if blog with such id doesn't exist in DB</returns>
        [HttpGet]
        [Route("{id}/articles")]
        public async Task<ActionResult<IEnumerable<ArticleModel>>> GetArticlesByBlogId(int id)
        {
            var articles = await _blogService.GetArticlesByBlogId(id);

            if (articles == null)
                return NotFound();

            return Ok(articles);
        }

        /// <summary>
        /// Gets recently created blogs
        /// </summary>
        /// <param name="count">Number of blogs to load</param>
        /// <returns></returns>
        [HttpGet("latest/{count?}")]
        public ActionResult<IEnumerable<BlogModel>> GetLatest(int count = 5)
        {
            return Ok(_blogService.GetLatest(count));
        }
    }
}
