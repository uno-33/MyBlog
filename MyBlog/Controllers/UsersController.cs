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
            return await _userService.AddUserToRoleAsync(id, role);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        // GET: api/users/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> UpdateById(string id)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        // GET: api/users/5/comments
        [HttpGet]
        [Route("{id}/comments")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetAllCommentsByUserId(string id)
        {
            throw new NotImplementedException();
        }

        // GET: api/users/5/articles
        [HttpGet]
        [Route("{id}/articles")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArticleModel>>> GetAllArticlesByUserId(string id)
        {
            throw new NotImplementedException();
        }

        // GET: api/users/5/blogs
        [HttpGet]
        [Route("{id}/blogs")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BlogModel>>> GetAllBlogsByUserId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
