using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
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
		private readonly ClaimsPrincipal _user;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
		}

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
			//var userId = Guid.Parse("DB1CDE1F-A458-428B-B0E2-AFE00C24C7B8");

			
			var userId=_user.GetLogInUserId();
			var userEmail=_user.GetLogInUserEmail();

			var imageId = Guid.Parse("4028094A-6692-442E-8952-555355BDAF74");

			var article = new Article(articleAddDto.Title, articleAddDto.Content, userId,userEmail,articleAddDto.CategoryId, imageId);
			

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
			var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category);
			var map = mapper.Map<ArticleDto>(article);
			return map;
		}
		public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
		{
			var userEmail=_user.GetLogInUserEmail();
			var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
			article.Title = articleUpdateDto.Title;
			article.Content = articleUpdateDto.Content;
			article.CategoryId = articleUpdateDto.CategoryId;
			article.ModifiedDate=DateTime.Now;
			article.ModifiedBy=userEmail;

			await unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await unitOfWork.SaveAsync();

			return article.Title;
		}

		public async Task <string>SafeDeleteArticleAsync(Guid articleId)
		{

			var userEmail = _user.GetLogInUserEmail();

			var article =await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
			article.IsDeleted = true;
			article.DeletedDate= DateTime.Now;
			article.DeletedBy=userEmail;

			await unitOfWork.GetRepository<Article>().UpdateAsync(article);

			await unitOfWork.SaveAsync();
			return article.Title;
		}
	}
}
