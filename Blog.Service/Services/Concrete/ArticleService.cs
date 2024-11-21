using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
			var userId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C");

			var article = new Article
			{
				Title = articleAddDto.Title,
				Content = articleAddDto.Content,
				CategoryId = articleAddDto.CategoryId,
				UserId = userId
			};

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
		public async Task UpdateArticleAysnc(ArticleUpdateDto articleUpdateDto)
		{
			var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);

			article.Title = articleUpdateDto.Title;
			article.Content = articleUpdateDto.Content;
			article.CategoryId = articleUpdateDto.CategoryId;

			await unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await unitOfWork.SaveAsync();

		}
	}
}
