using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyBlogBLL.Interfaces;
using MyBlogBLL.Models;
using MyBlogDAL.Entities;
using MyBlogDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> AddUserToRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;

            var result = await _userManager.AddToRoleAsync(user, role);

            return result.Succeeded;
        }

        public async Task<bool> RemoveUserFromRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;

            var result = await _userManager.RemoveFromRoleAsync(user, role);

            return result.Succeeded;
        }

        public async Task<UserModel> GetByIdAsync(string id)
        {
            var entity = await _userManager.FindByIdAsync(id);

            return _mapper.Map<UserModel>(entity);
        }

        public IEnumerable<UserModel> GetAll()
        {
            var users = _userManager.Users.ToList();

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<bool> UpdateByIdAsync(string id, UserModel model)
        {
            var entity = await _userManager.FindByIdAsync(id);
            if (entity == null)
                return false;

            model.Id = id;

            entity.UserName = model.UserName;
            // TODO: finish this up

            var result = await _userManager.UpdateAsync(entity);

            return result.Succeeded;
        }
        public async Task<bool> DeleteByIdAsync(string id)
        {
            var entity = await _userManager.FindByIdAsync(id);

            if (entity == null)
                return false;

            var result = await _userManager.DeleteAsync(entity);

            return result.Succeeded;
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsByUserIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return null;

            return _mapper.Map<IEnumerable<CommentModel>>(user.Comments);
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesByUserIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return null;

            return _mapper.Map<IEnumerable<ArticleModel>>(user.Articles);
        }

        public async Task<IEnumerable<BlogModel>> GetBlogsByUserIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return null;

            return _mapper.Map<IEnumerable<BlogModel>>(user.Blogs);
        }

    }
}
