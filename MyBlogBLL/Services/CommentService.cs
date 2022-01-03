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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(CommentModel model)
        {
            ValidateCommentModel(model);

            var entity = _mapper.Map<Comment>(model);

            await _unitOfWork.CommentRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(CommentModel model)
        {
            ValidateCommentModel(model);

            var entity = _mapper.Map<Comment>(model);

            _unitOfWork.CommentRepository.Delete(entity);
            _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.CommentRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public IEnumerable<CommentModel> GetAll()
        {
            var entities = _unitOfWork.CommentRepository.FindAll();

            return _mapper.Map<IEnumerable<CommentModel>>(entities);
        }

        public async Task<CommentModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            return _mapper.Map<CommentModel>(entity);
        }

        public void Update(CommentModel model)
        {
            ValidateCommentModel(model);

            var entity = _mapper.Map<Comment>(model);

            _unitOfWork.CommentRepository.Update(entity);
            _unitOfWork.SaveAsync();
        }

        private void ValidateCommentModel(CommentModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (!model.IsValid())
                throw new BlogException("CommentModel is invalid!");
        }
    }
}
