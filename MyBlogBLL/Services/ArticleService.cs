using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    /// Class representing manager of articles
    /// </summary>
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// ArticleService controller
        /// </summary>
        /// <param name="unitOfWork">Implementation of IUnitOfWork</param>
        /// <param name="mapper">Implementation of IMapper</param>
        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds article to DB
        /// </summary>
        /// <param name="model">ArticleModel to add</param>
        /// <returns></returns>
        public async Task AddAsync(ArticleModel model)
        {
            ValidateArticleModel(model);

            var entity = _mapper.Map<Article>(model);

            await _unitOfWork.ArticleRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            model.Id = entity.Id;
        }

        /// <summary>
        /// Deletes article from DB by id
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>true if successful, false if article not found</returns>
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.ArticleRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        /// <summary>
        /// Gets all articles
        /// </summary>
        /// <returns>IEnumerable of ArticleModel</returns>
        public IEnumerable<ArticleModel> GetAll()
        {
            var entities = _unitOfWork.ArticleRepository.FindAll();

            return _mapper.Map<IEnumerable<ArticleModel>>(entities);
        }

        /// <summary>
        /// Get latest articles
        /// </summary>
        /// <param name="count">Number to get</param>
        /// <returns></returns>
        public IEnumerable<ArticleModel> GetLatest(int count = 5)
        {
            var entities = _unitOfWork.ArticleRepository.FindAll()
                .Include(x => x.Creator)
                .OrderByDescending(x => x.DateOfCreation)
                .Take(count);

            return _mapper.Map<IEnumerable<ArticleModel>>(entities);
        }

        /// <summary>
        /// Gets article by id
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>ArticleModel</returns>
        public async Task<ArticleModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            return _mapper.Map<ArticleModel>(entity);
        }

        /// <summary>
        /// Gets article by id
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>ArticleModel</returns>
        public async Task<ArticleModel> GetByIdWithDetailsAsync(int id)
        {
            var entity = await _unitOfWork.ArticleRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<ArticleModel>(entity);
        }

        /// <summary>
        /// Update article
        /// </summary>
        /// <param name="id">Id of article</param>
        /// <param name="inputModel">Title and Content of article</param>
        /// <returns>Id of article</returns>
        public async Task<int> Update(int id, ArticleInputModel inputModel)
        {
            var entity = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            if (entity == null)
                throw new ArgumentException("There is no article with such Id.");

            entity.Title = inputModel.Title;
            entity.Content = inputModel.Content;

            _unitOfWork.ArticleRepository.Update(entity);
            await _unitOfWork.SaveAsync();

            return entity.Id;
        }

        /// <summary>
        /// Gets all articles containing text
        /// </summary>
        /// <param name="text"></param>
        /// <returns>IEnumerable of ArticleModel</returns>
        public IEnumerable<ArticleModel> GetByMatchingText(string text)
        {
            var articles = _unitOfWork.ArticleRepository
                .FindAll()
                .Where(x => x.Content.Contains(text))
                .Include(x => x.Creator);

            return _mapper.Map<IEnumerable<ArticleModel>>(articles);
        }

        /// <summary>
        /// Gets all articles containing tag
        /// </summary>
        /// <param name="tagName">Name of the tag</param>
        /// <returns>IEnumerable of ArticleModel</returns>
        public async Task<IEnumerable<ArticleModel>> GetByTagAsync(string tagName)
        {
            var tag = await _unitOfWork.TagRepository.GetByNameAsync(tagName);

            if (tag == null)
                throw new ArgumentException("There is no such tag!");

            var articles = _unitOfWork.ArticleRepository
                .FindAll()
                .Include(x => x.Tags)
                .Include(x => x.Creator)
                .Where(x => x.Tags.Contains(tag));

            return _mapper.Map<IEnumerable<ArticleModel>>(articles);
        }

        private void ValidateArticleModel(ArticleModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (!model.IsValid())
                throw new BlogException("ArticleModel is invalid!");
        }
    }
}
