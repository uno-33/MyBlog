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
    /// Controller for article service
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        /// <summary>
        /// Article controller constructor
        /// </summary>
        /// <param name="articleService">Implementation of articleService</param>
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// Gets all articles
        /// </summary>
        /// <returns>IEnumerable of ArticleModel</returns>
        // GET: api/<ArticlesController>
        [HttpGet]
        public ActionResult<IEnumerable<ArticleModel>> GetAll()
        {
            return Ok(_articleService.GetAll());
        }

        /// <summary>
        /// Gets article by id
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>ArticleModel or NotFound if blog with such id doesn't exist</returns>
        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleModel>> GetById(int id)
        {
            var article = await _articleService.GetByIdAsync(id);

            if (article == null)
                return NotFound();

            return Ok(article);
        }

        /// <summary>
        /// Creates new article
        /// </summary>
        /// <param name="articleViewModel">ArticleViewModel to create in DB</param>
        /// <returns>OK if successful, BadRequest if not</returns>
        // POST api/<ArticlesController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ArticleModel>> Create([FromBody] ArticleViewModel articleViewModel)
        {
            try
            {
                var model = new ArticleModel
                {
                    Title = articleViewModel.Title,
                    Content = articleViewModel.Content,
                    BlogId = articleViewModel.BlogId,
                    CreatorId = HttpContext.User.Identity.Name,
                    DateOfCreation = DateTime.Now
                };
                await _articleService.AddAsync(model);
                return Ok(model);
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

        /// <summary>
        /// Updates article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <param name="articleModel">ArticleModel to update</param>
        /// <returns>OK if successful, BadRequest if not</returns>
        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ArticleModel>> Update(int id, [FromBody] ArticleViewModel articleViewModel)
        {
            try
            {
                var model = await _articleService.GetByIdAsync(id);
                if (model == null)
                    return NotFound();

                model.Title = articleViewModel.Title;
                model.Content = articleViewModel.Content;

                _articleService.Update(model);
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
        /// Deletes article from DB
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>OK is successful, NotFound if article with such id doesn't exist in DB</returns>
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

        /// <summary>
        /// Gets all comments from ceratin article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>IEnumerable of CommentModel or NotFound if article with such id doesn't exist in DB</returns>
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

        /// <summary>
        /// Gets all tags from certain article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>IEnumerable of TagModel or NotFound if article with such id doesn't exist in DB</returns>
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

        /// <summary>
        /// Gets articles by matching text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public ActionResult<IEnumerable<ArticleModel>> GetByText(string text)
        {
            return Ok(_articleService.GetByMatchingText(text));
        }

        /// <summary>
        /// Gets articles by tag
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        [HttpGet("tag")]
        public ActionResult<IEnumerable<ArticleModel>> GetByTag(string tagName)
        {
            return Ok(_articleService.GetByTag(tagName));
        }

        /// <summary>
        /// Gets recently created articles
        /// </summary>
        /// <param name="count">Number of articles to load</param>
        /// <returns></returns>
        [HttpGet("latest/{count?}")]
        public ActionResult<IEnumerable<ArticleModel>> GetLatest(int count = 5)
        {
            return Ok(_articleService.GetLatest(count));
        }
    }
}
