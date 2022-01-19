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
