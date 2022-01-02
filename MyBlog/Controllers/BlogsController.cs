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
    [Produces("application/json")]
    public class BlogsController : ControllerBase
    {
        // GET: api/<BlogsController>
        [HttpGet]
        public ActionResult<IEnumerable<BlogModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public ActionResult<BlogModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<BlogsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BlogModel>> Add([FromBody] BlogModel blogModel)
        {
            throw new NotImplementedException();
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<BlogModel>> Update(int id, [FromBody] BlogModel blogModel)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id}/articles")]
        public ActionResult<IEnumerable<ArticleModel>> GetAllArticlesByBlogId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
