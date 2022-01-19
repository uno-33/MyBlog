using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlogBLL.Models;
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
        /// Updates article
        /// </summary>
        /// <param name="model">ArticleModel to update</param>
        public void Update(ArticleModel model)
        {
            ValidateArticleModel(model);

            var entity = _mapper.Map<Article>(model);

            _unitOfWork.ArticleRepository.Update(entity);
            _unitOfWork.SaveAsync();
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
                .Where(x => x.Content.Contains(text));

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
                throw new BlogException("Tag not found!");

            var articles = _unitOfWork.ArticleRepository
                .FindAll().Include(x => x.Tags)
                .Where(x => x.Tags.Contains(tag))
                .AsEnumerable();

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
