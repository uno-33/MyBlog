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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        // GET: api/<ArticlesController>
        [HttpGet]
        public ActionResult<IEnumerable<ArticleModel>> GetAll()
        {
            return Ok(_articleService.GetAll());
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleModel>> GetById(int id)
        {
            var article = await _articleService.GetByIdAsync(id);

            if (article == null)
                return NotFound();

            return Ok(article);
        }

        // POST api/<ArticlesController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] ArticleModel articleModel)
        {
            try
            {
                await _articleService.AddAsync(articleModel);
                return Ok();
            }
            catch (BlogException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<ArticleModel> Update(int id, [FromBody] ArticleModel articleModel)
        {
            try
            {
                _articleService.Update(articleModel);
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

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _articleService.DeleteByIdAsync(id);

            if (result)
                return Ok();

            return NotFound();
        }

        // GET: api/articles/5/comments
        [HttpGet]
        [Route("{id}/comments")]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetCommentsByArticleId(int id)
        {
            var comments = await _articleService.GetCommentsByArticleId(id);
            
            if (comments == null)
                return NotFound();

            return Ok(comments);
        }

        // GET: api/articles/5/tags
        [HttpGet]
        [Route("{id}/tags")]
        public async Task<ActionResult<IEnumerable<TagModel>>> GetAllTagsByArticleId(int id)
        {
            var tags = await _articleService.GetTagsByArticleId(id);

            if (tags == null)
                return NotFound();

            return Ok(tags);
        }
    }
}
