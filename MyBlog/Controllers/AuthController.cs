using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Interfaces;
using MyBlogBLL.Models;
using MyBlogBLL.Models.InputModels;
using MyBlogBLL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    /// <summary>
    /// Controller for login system
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Login system constructor
        /// </summary>
        /// <param name="authService">Implementation of accountService</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Registers user in DB
        /// </summary>
        /// <param name="model">Model with username and password inside</param>
        /// <returns>true if register is successful</returns>
        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(AuthInputModel model)
        {
            return await _authService.RegisterAsync(model);

        }

        /// <summary>
        /// Signs In user
        /// </summary>
        /// <param name="model">Model with username and password inside</param>
        /// <returns>UserModel with JWT inside</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthModel>> Login(AuthInputModel model)
        {
            return await _authService.LoginAsync(model);
        }
    }
}
