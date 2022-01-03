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
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ArticleModel model)
        {
            ValidateArticleModel(model);

            var entity = _mapper.Map<Article>(model);

            await _unitOfWork.ArticleRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(ArticleModel model)
        {
            ValidateArticleModel(model);

            var entity = _mapper.Map<Article>(model);

            _unitOfWork.ArticleRepository.Delete(entity);
            _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.ArticleRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public IEnumerable<ArticleModel> GetAll()
        {
            var entities = _unitOfWork.ArticleRepository.FindAll();

            return _mapper.Map<IEnumerable<ArticleModel>>(entities);
        }

        public async Task<ArticleModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            return _mapper.Map<ArticleModel>(entity);
        }

        public void Update(ArticleModel model)
        {
            ValidateArticleModel(model);

            var entity = _mapper.Map<Article>(model);

            _unitOfWork.ArticleRepository.Update(entity);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsByArticleId(int id)
        {
            var entities = await _unitOfWork.ArticleRepository.GetCommentsByArticleId(id);

            return _mapper.Map<IEnumerable<CommentModel>>(entities);
        }

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
