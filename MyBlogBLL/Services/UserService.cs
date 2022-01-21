using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlogBLL.Interfaces;
using MyBlogBLL.Models;
using MyBlogBLL.Models.InputModels;
using MyBlogDAL.Entities;
using MyBlogDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    /// <summary>
    /// Class representing user manager
    /// </summary>
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// UserService controller
        /// </summary>
        /// <param name="userManager">Implementation of UserManager<User></param>
        /// <param name="mapper">Implementation of IMapper</param>
        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds user to role
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="role">Role name</param>
        /// <returns>true if successful, false if role or user not found</returns>
        public async Task<bool> AddUserToRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;

            var result = await _userManager.AddToRoleAsync(user, role);

            return result.Succeeded;
        }

        /// <summary>
        /// Removes user from role
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="role">Role name</param>
        /// <returns>true if successful, false if role or user not found</returns>
        public async Task<bool> RemoveUserFromRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;

            var result = await _userManager.RemoveFromRoleAsync(user, role);

            return result.Succeeded;
        }

        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>UserModel</returns>
        public async Task<UserModel> GetByIdAsync(string id)
        {
            var entity = await _userManager.FindByIdAsync(id);

            return _mapper.Map<UserModel>(entity);
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>IEnumerable of UserModel</returns>
        public IEnumerable<UserModel> GetAll()
        {
            var users = _userManager.Users.ToList();

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        /// <summary>
        /// Updates user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="model">UserModel</param>
        /// <returns>true if successful, false if user not found</returns>
        public async Task<string> UpdateByIdAsync(string id, UserInputModel inputModel)
        {
            var entity = await _userManager.FindByIdAsync(id);
            if (entity == null)
                throw new ArgumentException("There is no user with such Id");

            entity.UserName = inputModel.UserName;

            await _userManager.UpdateAsync(entity);

            return entity.Id;
        }

        /// <summary>
        /// Deletes user from DB by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>true if successful, false if user not found</returns>
        public async Task<bool> DeleteByIdAsync(string id)
        {
            var entity = await _userManager.FindByIdAsync(id);

            if (entity == null)
                return false;

            var result = await _userManager.DeleteAsync(entity);

            return result.Succeeded;
        }

        /// <summary>
        /// Gets all comments made by user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>IEnumerable of CommentModel or null if user nor found</returns>
        public async Task<IEnumerable<CommentModel>> GetCommentsByUserIdAsync(string id)
        {
            var user = await _userManager.Users
                .Where(x => x.Id == id)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync();

            if (user == null)
                return null;

            return _mapper.Map<IEnumerable<CommentModel>>(user.Comments);
        }

        /// <summary>
        /// Gets all articles created by user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>IEnumerable of ArticleModel or null if user nor found</returns>
        public async Task<IEnumerable<ArticleModel>> GetArticlesByUserIdAsync(string id)
        {
            var user = await _userManager.Users
                .Where(x => x.Id == id)
                .Include(x => x.Articles)
                .FirstOrDefaultAsync();

            if (user == null)
                return null;

            return _mapper.Map<IEnumerable<ArticleModel>>(user.Articles);
        }

        /// <summary>
        /// Gets all blogs created by user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>IEnumerable of BlogModel or null if user nor found</returns>
        public async Task<IEnumerable<BlogModel>> GetBlogsByUserIdAsync(string id)
        {
            var user = await _userManager.Users
                .Where(x => x.Id == id)
                .Include(x => x.Blogs)
                .FirstOrDefaultAsync();

            if (user == null)
                return null;

            return _mapper.Map<IEnumerable<BlogModel>>(user.Blogs);
        }

        /// <summary>
        /// Gets all user roles
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>IEnumerable of string or null if user nor found</returns>
        public async Task<IEnumerable<string>> GetRolesByUserIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return null;

            return await _userManager.GetRolesAsync(user);
        }

    }
}
