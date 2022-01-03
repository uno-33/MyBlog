using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Interfaces;
using MyBlogBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("addtorole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> AddUserToRoleAsync(string id, string role)
        {
            var result = false;
            try
            {
                result = await _userService.AddUserToRoleAsync(id, role);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpPost("removefromrole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> RemoveUserFromRole(string id, string role)
        {
            var result = false;
            try
            {
                result = await _userService.RemoveUserFromRoleAsync(id, role);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            if (!result)
                return NotFound();

            return Ok();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> GetByIdAsync(string id)
        {
            var model = await _userService.GetByIdAsync(id);

            if (User.Identity.Name != model?.UserName && !User.IsInRole("Admin"))
                return Forbid();

            if (model == null)
                return NotFound("There is not user with such ID");

            return Ok(model);
        }

        // GET: api/users/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<UserModel>> GetAll()
        {
            var users = _userService.GetAll();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(string id, UserModel model)
        {
            var result = await _userService.UpdateByIdAsync(id, model);

            if (!result)
                return NotFound();

            return Ok();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(string id)
        {
            var result = await _userService.DeleteByIdAsync(id);

            if (!result)
                return NotFound();

            return Ok();
        }

        // GET: api/users/5/comments
        [HttpGet]
        [Route("{id}/comments")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetAllCommentsByUserId(string id)
        {
            var comments = await _userService.GetCommentsByUserIdAsync(id);

            if (comments == null)
                return NotFound();

            return Ok(comments);
        }

        // GET: api/users/5/articles
        [HttpGet]
        [Route("{id}/articles")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArticleModel>>> GetAllArticlesByUserId(string id)
        {
            var articles = await _userService.GetArticlesByUserIdAsync(id);

            if (articles == null)
                return NotFound();

            return Ok(articles);
        }

        // GET: api/users/5/blogs
        [HttpGet]
        [Route("{id}/blogs")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BlogModel>>> GetAllBlogsByUserId(string id)
        {
            var blogs = await _userService.GetBlogsByUserIdAsync(id);

            if (blogs == null)
                return NotFound();

            return Ok(blogs);
        }
    }
}
