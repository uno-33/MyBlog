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
    public class TagsController : ControllerBase
    {
        // GET: api/<TagsController>
        [HttpGet]
        public ActionResult<IEnumerable<TagModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public ActionResult<TagModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        // GET api/<TagsController>/5
        [HttpGet("{name}")]
        public ActionResult<TagModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        // POST api/<TagsController>
        [HttpPost]
        public ActionResult<TagModel> Create([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        public ActionResult<TagModel> Update(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
