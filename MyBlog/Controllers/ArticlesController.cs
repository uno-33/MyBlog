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
    public class ArticlesController : ControllerBase
    {
        // GET: api/<ArticlesController>
        [HttpGet]
        public IEnumerable<ArticleModel> GetAll()
        {
            throw new NotImplementedException();
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public ArticleModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ArticlesController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ArticleModel>> Create([FromBody] ArticleModel articleModel)
        {
            throw new NotImplementedException();
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ArticleModel>> Update(int id, [FromBody] ArticleModel articleModel)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        // GET: api/articles/5/comments
        [HttpGet]
        [Route("{id}/comments")]
        public ActionResult<IEnumerable<CommentModel>> GetAllCommentsByArticleId(int id)
        {
            throw new NotImplementedException();
        }

        // GET: api/articles/5/tags
        [HttpGet]
        [Route("{id}/tags")]
        public ActionResult<IEnumerable<TagModel>> GetAllTagsByArticleId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
