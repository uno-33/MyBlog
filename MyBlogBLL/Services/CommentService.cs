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
    /// Class representing manager of comments
    /// </summary>
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// CommentService controller
        /// </summary>
        /// <param name="unitOfWork">Implementation of IUnitOfWork</param>
        /// <param name="mapper">Implementation of IMapper</param>
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds comment to DB
        /// </summary>
        /// <param name="model">CommentModel to add</param>
        /// <returns></returns>
        public async Task AddAsync(CommentModel model)
        {
            ValidateCommentModel(model);

            var entity = _mapper.Map<Comment>(model);

            await _unitOfWork.CommentRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Deletes comment from DB by model
        /// </summary>
        /// <param name="model">CommentModel to delete</param>
        public void Delete(CommentModel model)
        {
            ValidateCommentModel(model);

            var entity = _mapper.Map<Comment>(model);

            _unitOfWork.CommentRepository.Delete(entity);
            _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Deletes comment from DB by id
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <returns>true if successful, false if comment not found</returns>
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.CommentRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <returns>IEnumerable of CommentModel</returns>
        public IEnumerable<CommentModel> GetAll()
        {
            var entities = _unitOfWork.CommentRepository.FindAll();

            return _mapper.Map<IEnumerable<CommentModel>>(entities);
        }

        /// <summary>
        /// Gets comment by id
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <returns>CommentModel</returns>
        public async Task<CommentModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            return _mapper.Map<CommentModel>(entity);
        }

        /// <summary>
        /// Updates comment
        /// </summary>
        /// <param name="model">CommentModel to update</param>
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
