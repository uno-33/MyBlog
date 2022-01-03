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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET: api/<CommentsController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<CommentModel>> GetAll()
        {
            return Ok(_commentService.GetAll());
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentModel>> GetById(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        // POST api/<CommentsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentModel>> Create([FromBody] CommentModel commentModel)
        {
            try
            {
                await _commentService.AddAsync(commentModel);
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

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<CommentModel> Update(int id, [FromBody] CommentModel commentModel)
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
