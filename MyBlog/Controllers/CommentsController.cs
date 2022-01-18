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
    /// Controller for comment service
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        /// <summary>
        /// Comment controller constructor
        /// </summary>
        /// <param name="commentService">Implementation of commentService</param>
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <returns>IEnumerable of CommentModel</returns>
        // GET: api/<CommentsController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<CommentModel>> GetAll()
        {
            return Ok(_commentService.GetAll());
        }

        /// <summary>
        /// Get comment by id
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <returns>CommentModel or NotFound if comment with such id doesn't exist</returns>
        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentModel>> GetById(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        /// <summary>
        /// Creates new comment
        /// </summary>
        /// <param name="commentViewModel">CommentViewModel to create</param>
        /// <returns>OK if successful, BadRequest if not</returns>
        // POST api/<CommentsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] CommentViewModel commentViewModel)
        {
            try
            {
                var model = new CommentModel
                {
                    Content = commentViewModel.Content,
                    ArticleId = commentViewModel.ArticleId,
                    DateOfCreation = DateTime.Now,
                    AuthorId = HttpContext.User.Identity.Name
                };
                await _commentService.AddAsync(model);
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
        /// Updates comment
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <param name="commentModel">CommentModel to update</param>
        /// <returns>OK if successful, BadRequest if not</returns>
        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Update(int id, [FromBody] CommentModel commentModel)
        {
            try
            {
                _commentService.Update(commentModel);
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
        /// Deletes comment from DB
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <returns>OK is successful, NotFound if article with such id doesn't exist in DB</returns>
        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _commentService.DeleteByIdAsync(id);

            if (result)
                return Ok();

            return NotFound();
        }
    }
}
