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
    /// <summary>
    /// Controller for tag service
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        /// <summary>
        /// Tag controller constructor
        /// </summary>
        /// <param name="tagService">Implementation of tagService</param>
        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Gets all tags
        /// </summary>
        /// <returns>IEnumerable of TagModel</returns>
        // GET: api/<TagsController>
        [HttpGet]
        public ActionResult<IEnumerable<TagModel>> GetAll()
        {
            return Ok(_tagService.GetAll());
        }

        /// <summary>
        /// Get tag by id
        /// </summary>
        /// <param name="id">Tag id</param>
        /// <returns>TagModel or NotFound if tag with such id doesn't exist</returns>
        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagModel>> GetById(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);

            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        /// <summary>
        /// Gets tag by name
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <returns>TagModel</returns>
        // GET api/<TagsController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<TagModel>> GetByName(string name)
        {
            var tag = await _tagService.GetByNameAsync(name);

            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        /// <summary>
        /// Creates new tag
        /// </summary>
        /// <param name="tagModel">TagModel to create</param>
        /// <returns>OK if successful, BadRequest if not</returns>
        // POST api/<TagsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] TagModel tagModel)
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

        /// <summary>
        /// Updates tag
        /// </summary>
        /// <param name="id">Tag id</param>
        /// <param name="tagModel">TagModel to update</param>
        /// <returns>OK if successful, BadRequest if not</returns>
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

        /// <summary>
        /// Deletes tag from DB
        /// </summary>
        /// <param name="id">Tag id</param>
        /// <returns>OK is successful, NotFound if tag with such id doesn't exist in DB</returns>
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
