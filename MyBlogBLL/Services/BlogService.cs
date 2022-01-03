using AutoMapper;
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
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(BlogModel model)
        {
            ValidateBlogModel(model);

            var entity = _mapper.Map<Blog>(model);

            await _unitOfWork.BlogRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(BlogModel model)
        {
            ValidateBlogModel(model);

            var entity = _mapper.Map<Blog>(model);

            _unitOfWork.BlogRepository.Delete(entity);
            _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.BlogRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.BlogRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public IEnumerable<BlogModel> GetAll()
        {
            var entities = _unitOfWork.BlogRepository.FindAll();

            return _mapper.Map<IEnumerable<BlogModel>>(entities);
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesByBlogId(int id)
        {
            var entities = await _unitOfWork.BlogRepository.GetArticlesByBlogId(id);

            return _mapper.Map<IEnumerable<ArticleModel>>(entities);
        }

        public async Task<BlogModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.BlogRepository.GetByIdAsync(id);
            return _mapper.Map<BlogModel>(entity);
        }

        public void Update(BlogModel model)
        {
            ValidateBlogModel(model);

            var entity = _mapper.Map<Blog>(model);

            _unitOfWork.BlogRepository.Update(entity);
            _unitOfWork.SaveAsync();
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
