using AutoMapper;
using MyBlogBLL.Models;
using MyBlogBLL.Models.InputModels;
using MyBlogBLL.Validation;
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
    /// Class representing manager of blogs
    /// </summary>
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// BlogService controller
        /// </summary>
        /// <param name="unitOfWork">Implementation of IUnitOfWork</param>
        /// <param name="mapper">Implementation of IMapper</param>
        public BlogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds blog to DB
        /// </summary>
        /// <param name="model">BlogModel to add</param>
        /// <returns></returns>
        public async Task AddAsync(BlogModel model)
        {
            ValidateBlogModel(model);

            var entity = _mapper.Map<Blog>(model);

            await _unitOfWork.BlogRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            model.Id = entity.Id;
        }

        /// <summary>
        /// Deletes blog from DB by model
        /// </summary>
        /// <param name="model">BlogModel to delete</param>
        public void Delete(BlogModel model)
        {
            ValidateBlogModel(model);

            var entity = _mapper.Map<Blog>(model);

            _unitOfWork.BlogRepository.Delete(entity);
            _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Deletes blog from DB by id
        /// </summary>
        /// <param name="id">Blog id</param>
        /// <returns>true if successful, false if blog not found</returns>
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.BlogRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.BlogRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        /// <summary>
        /// Gets all blogs
        /// </summary>
        /// <returns>IEnumerable of BlogModel</returns>
        public IEnumerable<BlogModel> GetAll()
        {
            var entities = _unitOfWork.BlogRepository.FindAll().ToList();

            return _mapper.Map<IEnumerable<BlogModel>>(entities);
        }

        /// <summary>
        /// Gets latest blogs
        /// </summary>
        /// <returns>IEnumerable of BlogModel</returns>
        public IEnumerable<BlogModel> GetLatest(int count = 5)
        {
            var entities = _unitOfWork.BlogRepository.FindAll()
                .OrderByDescending(x => x.Id)
                .Take(count);

            return _mapper.Map<IEnumerable<BlogModel>>(entities);
        }

        /// <summary>
        /// Gets all articles of this blog
        /// </summary>
        /// <param name="id">Blog id</param>
        /// <returns>IEnumerable of ArticleModel</returns>
        public async Task<IEnumerable<ArticleModel>> GetArticlesByBlogId(int id)
        {
            var entities = await _unitOfWork.BlogRepository.GetArticlesByBlogId(id);

            return _mapper.Map<IEnumerable<ArticleModel>>(entities);
        }

        /// <summary>
        /// Gets blog by id
        /// </summary>
        /// <param name="id">Blog id</param>
        /// <returns>BlogModel</returns>
        public async Task<BlogModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.BlogRepository.GetByIdAsync(id);

            return _mapper.Map<BlogModel>(entity);
        }

        /// <summary>
        /// Gets blog by id with details
        /// </summary>
        /// <param name="id">Blog id</param>
        /// <returns>BlogModel</returns>
        public async Task<BlogModel> GetByIdWithDetailsAsync(int id)
        {
            var entity = await _unitOfWork.BlogRepository.GetByIdWithDetailsAsync(id);

            return _mapper.Map<BlogModel>(entity);
        }

        /// <summary>
        /// Updates blog
        /// </summary>
        /// <param name="model">BlogModel to update</param>
        public async Task<int> Update(int id, BlogInputModel inputModel)
        {
            var entity = await _unitOfWork.BlogRepository.GetByIdAsync(id);
            if (entity == null)
                throw new ArgumentException("There is no blog with such Id.");

            entity.Name = inputModel.Name;
            entity.Description = inputModel.Description;

            _unitOfWork.BlogRepository.Update(entity);
            await _unitOfWork.SaveAsync();

            return entity.Id;
        }

        private void ValidateBlogModel(BlogModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (!model.IsValid())
                throw new BlogException("BlogModel is invalid!");
        }
    }
}
