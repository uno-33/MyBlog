using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Models;
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
        // GET: api/<CommentsController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<CommentModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public ActionResult<CommentModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<CommentsController>
        [HttpPost]
        [Authorize]
        public ActionResult<CommentModel> Create([FromBody] CommentModel commentModel)
        {
            throw new NotImplementedException();
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<CommentModel> Update(int id, [FromBody] CommentModel commentModel)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
