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
    public class TagsController : ControllerBase
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService)
        {
            _tagService = tagService;
        }
        // GET: api/<TagsController>
        [HttpGet]
        public ActionResult<IEnumerable<TagModel>> GetAll()
        {
            return Ok(_tagService.GetAll());
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagModel>> GetById(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);

            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        // GET api/<TagsController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<TagModel>> GetByName(string name)
        {
            var tag = await _tagService.GetByNameAsync(name);

            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        // POST api/<TagsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TagModel>> Create([FromBody] TagModel tagModel)
        {
            try
            {
                await _tagService.AddAsync(tagModel);
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

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<TagModel> Update(int id, [FromBody] TagModel tagModel)
        {
            try
            {
                _tagService.Update(tagModel);
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

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _tagService.DeleteByIdAsync(id);

            if (result)
                return Ok();

            return NotFound();
        }
    }
}
