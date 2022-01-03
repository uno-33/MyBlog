using AutoMapper;
using MyBlogBLL.Models;
using MyBlogBLL.Validation;
using MyBlogDAL.Entities;
using MyBlogDAL.Interfaces;
using System;
using System.Collections.Generic;
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
        }

        /// <summary>
        /// Deletes article from DB by model
        /// </summary>
        /// <param name="model">ArticleModel to delete</param>
        public void Delete(ArticleModel model)
        {
            ValidateArticleModel(model);

            var entity = _mapper.Map<Article>(model);

            _unitOfWork.ArticleRepository.Delete(entity);
            _unitOfWork.SaveAsync();
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
        /// Gets all comments related to this article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>IEnumerable of CommentModel</returns>
        public async Task<IEnumerable<CommentModel>> GetCommentsByArticleId(int id)
        {
            var entities = await _unitOfWork.ArticleRepository.GetCommentsByArticleId(id);

            return _mapper.Map<IEnumerable<CommentModel>>(entities);
        }

        /// <summary>
        /// Gets all tags related to this article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>IEnumerable of TagModel</returns>
        public async Task<IEnumerable<TagModel>> GetTagsByArticleId(int id)
        {
            var entities = await _unitOfWork.ArticleRepository.GetTagsByArticleId(id);

            return _mapper.Map<IEnumerable<TagModel>>(entities);
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
