﻿using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Entity.Enum;
using Blog.Service.Extensions;
using Blog.Service.Helpers.Images;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IImageHelper imageHelper;
		private readonly ClaimsPrincipal _user;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
			this.imageHelper = imageHelper;
		}
		public async Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			var article = categoryId == null
				? await unitOfWork.GetRepository<Article>()
				  .GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image)
				: await unitOfWork.GetRepository<Article>()
				  .GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted, x => x.Category, i => i.Image);


			var sortedArticles = isAscending
				? article.OrderBy(x => x.CreatedDate)
						 .Skip((currentPage - 1) * pageSize)
						 .Take(pageSize)
						 .ToList()
				: article.OrderByDescending(x => x.CreatedDate)
						 .Skip((currentPage - 1) * pageSize)
						 .Take(pageSize)
						 .ToList();
			return new ArticleListDto
			{
				Articles = sortedArticles,
				CategoryId = categoryId == null ? null : categoryId.Value,
				CurrentPage = currentPage,
				PageSize = pageSize,
				TotalCount = article.Count,
				IsAscending = isAscending

			};

		}

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{

			var userId = _user.GetLogInUserId();
			var userEmail = _user.GetLogInUserEmail();

			var imageUpload = await imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
			Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
			await unitOfWork.GetRepository<Image>().AddAsync(image);

			var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, userEmail, articleAddDto.CategoryId, image.Id);


			await unitOfWork.GetRepository<Article>().AddAsync(article);
			await unitOfWork.SaveAsync();
		}

		public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
		{

			var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
			var map = mapper.Map<List<ArticleDto>>(articles);

			return map;
		}
		public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
		{

			var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image);
			var map = mapper.Map<ArticleDto>(article);

			return map;
		}
		public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
		{
			var userEmail = _user.GetLogInUserEmail();
			var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);

			if (articleUpdateDto.Photo != null)
			{
				imageHelper.Delete(article.Image.FileName);

				var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
				Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
				await unitOfWork.GetRepository<Image>().AddAsync(image);

				article.ImageId = image.Id;

			}

			article.Title = articleUpdateDto.Title;
			article.Content = articleUpdateDto.Content;
			article.CategoryId = articleUpdateDto.CategoryId;
			article.ModifiedDate = DateTime.Now;
			article.ModifiedBy = userEmail;

			await unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await unitOfWork.SaveAsync();

			return article.Title;

		}
		public async Task<string> SafeDeleteArticleAsync(Guid articleId)
		{
			var userEmail = _user.GetLogInUserEmail();
			var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

			article.IsDeleted = true;
			article.DeletedDate = DateTime.Now;
			article.DeletedBy = userEmail;

			await unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await unitOfWork.SaveAsync();

			return article.Title;
		}

		public async Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedArticles()
		{
			var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
			var map = mapper.Map<List<ArticleDto>>(articles);
			return map;
		}

		public async Task<string> UndoDeleteArticleAsync(Guid articleId)
		{
			var userEmail = _user.GetLogInUserEmail();
			var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

			article.IsDeleted = false;
			article.DeletedDate = null;
			article.DeletedBy = null;

			await unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await unitOfWork.SaveAsync();

			return article.Title;
		}
	}
}