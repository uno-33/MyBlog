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
        /// Add tag to article
        /// </summary>
        /// <param name="articleId">Id of the article</param>
        /// <param name="tagName">Name of the tag</param>
        public async Task AddToArticleAsync(int articleId, string tagName)
        {
            var article = _unitOfWork
                .ArticleRepository
                .FindAll()
                .Include(x => x.Tags)
                .SingleOrDefault(x => x.Id == articleId);

            if (article == null)
                throw new ArgumentException("There is no article with such ID");

            var tag = await _unitOfWork
                .TagRepository
                .FindAll()
                .Include(x => x.Articles)
                .SingleOrDefaultAsync(x => x.Text == tagName);

            if (tag == null)
            {
                tag = new Tag
                {
                    Text = tagName,
                    Articles = new HashSet<Article>()
                };
                await _unitOfWork.TagRepository.AddAsync(tag);
                await _unitOfWork.SaveAsync();
            }

            article.Tags.Add(tag);
            tag.Articles.Add(article);

            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Get tag by name
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <returns>TagModel</returns>
        public async Task<TagModel> GetByNameAsync(string name)
        {
            var entity = await _unitOfWork.TagRepository.GetByNameAsync(name);

            return _mapper.Map<TagModel>(entity);
        }

        /// <summary>
        /// Get all tags related to this article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>IEnumerable of TagModel</returns>
        public async Task<IEnumerable<TagModel>> GetAllByArticleIdAsync(int id)
        {
            var article = await _unitOfWork
                .ArticleRepository
                .FindAll()
                .Include(x => x.Tags)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<IEnumerable<TagModel>>(article.Tags);
        }

        /// <summary>
        /// Remove tag from the article
        /// </summary>
        /// <param name="articleId">Id of the article</param>
        /// <param name="tagName">Name of the tag</param>
        /// <returns></returns>
        public async Task RemoveFromArticleAsync(int articleId, string tagName)
        {
            var article = _unitOfWork
                .ArticleRepository
                .FindAll()
                .Include(x => x.Tags)
                .SingleOrDefault(x => x.Id == articleId);

            if (article == null)
                throw new ArgumentException("There is no article with such ID");

            var tag = await _unitOfWork
                .TagRepository
                .FindAll()
                .Include(x => x.Articles)
                .SingleOrDefaultAsync(x => x.Text == tagName);

            if (tag == null)
                throw new ArgumentException("There is no tag with such name");

            article.Tags.Remove(tag);
            tag.Articles.Remove(article);

            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Delete tag from DB by id
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
    }
}
