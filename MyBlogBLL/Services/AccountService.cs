using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBlogBLL.Interfaces;
using MyBlogBLL.Models;
using MyBlogBLL.Validation;
using MyBlogDAL;
using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    /// <summary>
    /// Class representing login system
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly AuthSettings _authSettings;

        /// <summary>
        /// AccountService controller
        /// </summary>
        /// <param name="userManager">Implementation of UserManager</param>
        /// <param name="mapper">Implementation of IMapper</param>
        /// <param name="authSettings">Implementation of IOptions<AuthSettings></param>
        public AccountService(
            UserManager<User> userManager, 
            IMapper mapper, 
            IOptions<AuthSettings> authSettings)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authSettings = authSettings.Value;
        }

        /// <summary>
        /// Registers user in DB
        /// </summary>
        /// <param name="model">Model containing username and password</param>
        /// <returns>true if successful, false if not</returns>
        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            User user = new User { UserName = model.UserName, DateOfCreation = DateTime.Now };

            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Errors.Any())
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.Append(error.Description);
                    stringBuilder.Append(" ");
                }
                throw new BlogException(stringBuilder.ToString());
            }
            return result.Succeeded;
        }

        /// <summary>
        /// Signs in user in DB
        /// </summary>
        /// <param name="model">Model containing username and password</param>
        /// <returns>UserModel with JWT inside</returns>
        public async Task<UserModel> LoginAsync(LoginModel model)
        {
            var user = await GetUserByLoginModelAsync(model);

            var token = await GenerateTokenAsync(user);

            var userModel = _mapper.Map<UserModel>(user);

            userModel.Token = token;

            return userModel;
        }

        private async Task<User> GetUserByLoginModelAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
                throw new BlogException("There is no user with such username and password!");

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
                throw new BlogException("There is no user with such username and password!");

            return user;
        }

        private async Task<string> GenerateTokenAsync(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Secret));

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(_authSettings.LifetimeInMinutes),
                SigningCredentials = credentials,
                Audience = _authSettings.Audience
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
