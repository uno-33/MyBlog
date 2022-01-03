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
    /// Class representing manager of tags
    /// </summary>
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// TagService controller
        /// </summary>
        /// <param name="unitOfWork">Implementation of IUnitOfWork</param>
        /// <param name="mapper">Implementation of IMapper</param>
        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds tag to DB
        /// </summary>
        /// <param name="model">TagModel to add</param>
        /// <returns></returns>
        public async Task AddAsync(TagModel model)
        {
            ValidateTagModel(model);

            var entity = _mapper.Map<Tag>(model);

            await _unitOfWork.TagRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Deletes tag from DB by model
        /// </summary>
        /// <param name="model">TagModel to delete</param>
        public void Delete(TagModel model)
        {
            ValidateTagModel(model);

            var entity = _mapper.Map<Tag>(model);

            _unitOfWork.TagRepository.Delete(entity);
            _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Deletes tag from DB by id
        /// </summary>
        /// <param name="id">Tag id</param>
        /// <returns>true if successful, false if tag not found</returns>
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.TagRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.TagRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        /// <summary>
        /// Gets all tags
        /// </summary>
        /// <returns>IEnumerable of TagModel</returns>
        public IEnumerable<TagModel> GetAll()
        {
            var entities = _unitOfWork.TagRepository.FindAll();

            return _mapper.Map<IEnumerable<TagModel>>(entities);
        }

        /// <summary>
        /// Gets tag by id
        /// </summary>
        /// <param name="id">Tag id</param>
        /// <returns>TagModel</returns>
        public async Task<TagModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.TagRepository.GetByIdAsync(id);
            return _mapper.Map<TagModel>(entity);
        }

        /// <summary>
        /// Updates tag
        /// </summary>
        /// <param name="model">TagModel to update</param>
        public void Update(TagModel model)
        {
            ValidateTagModel(model);

            var entity = _mapper.Map<Tag>(model);

            _unitOfWork.TagRepository.Update(entity);
            _unitOfWork.SaveAsync();
        }

        private void ValidateTagModel(TagModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (!model.IsValid())
                throw new BlogException("TagModel is invalid!");
        }

        /// <summary>
        /// Gets tag by name
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <returns>TagModel</returns>
        public async Task<TagModel> GetByNameAsync(string name)
        {
            var entity = await _unitOfWork.TagRepository.GetByNameAsync(name);

            return _mapper.Map<TagModel>(entity);
        }
    }
}
