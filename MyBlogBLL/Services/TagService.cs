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
    public class TagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TagModel model)
        {
            ValidateTagModel(model);

            var entity = _mapper.Map<Tag>(model);

            await _unitOfWork.TagRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(TagModel model)
        {
            ValidateTagModel(model);

            var entity = _mapper.Map<Tag>(model);

            _unitOfWork.TagRepository.Delete(entity);
            _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.TagRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.TagRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public IEnumerable<TagModel> GetAll()
        {
            var entities = _unitOfWork.TagRepository.FindAll();

            return _mapper.Map<IEnumerable<TagModel>>(entities);
        }

        public async Task<TagModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.TagRepository.GetByIdAsync(id);
            return _mapper.Map<TagModel>(entity);
        }

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

        public async Task<Tag> GetByNameAsync(string name)
        {
            return await _unitOfWork.TagRepository.GetByNameAsync(name);
        }
    }
}
