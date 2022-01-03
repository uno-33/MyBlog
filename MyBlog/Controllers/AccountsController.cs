using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Interfaces;
using MyBlogBLL.Models;
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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        /// <summary>
        /// Login system constructor
        /// </summary>
        /// <param name="accountService">Implementation of accountService</param>
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Registers user in DB
        /// </summary>
        /// <param name="model">Model with username and password inside</param>
        /// <returns>true if register is successful</returns>
        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(RegisterModel model)
        {
            return await _accountService.RegisterAsync(model);

        }

        /// <summary>
        /// Signs In user
        /// </summary>
        /// <param name="model">Model with username and password inside</param>
        /// <returns>UserModel with JWT inside</returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(LoginModel model)
        {
            return await _accountService.LoginAsync(model);
        }
    }
}
