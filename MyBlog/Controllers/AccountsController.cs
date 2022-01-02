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
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(RegisterModel model)
        {
            return await _accountService.RegisterAsync(model);

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(LoginModel model)
        {
            return await _accountService.LoginAsync(model);
        }
    }
}
