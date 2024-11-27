using AutoMapper;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Blog.Web.ResultMessage;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ArticleController : Controller
	{
		private readonly IArticleService articleService;
		private readonly IToastNotification toastNotification;
		private readonly ICategoryService categoryService;
		private readonly IMapper mapper;
		private readonly IValidator<Article> validator;
		public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toastNotification)
		{
			this.toastNotification = toastNotification;
			this.validator = validator;
			this.articleService = articleService;
			this.categoryService = categoryService;
			this.mapper = mapper;
		}
		public async Task<IActionResult> Index()
		{
			var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
			return View(articles);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var categories = await categoryService.GetAllCategoriesNonDeleted();
			return View(new ArticleAddDto
			{ Categories = categories });
		}
		[HttpPost]
		public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
		{
			var map = mapper.Map<Article>(articleAddDto);
			var result = await validator.ValidateAsync(map);
			if (result.IsValid)
			{
				await articleService.CreateArticleAsync(articleAddDto);
				toastNotification.AddSuccessToastMessage(Message.Article.Add(articleTitle: articleAddDto.Title));
				return RedirectToAction("Index", "Article", new { Area = "Admin" });
			}
			else
			{
				result.AddToModelState(this.ModelState);
			}
			var categories = await categoryService.GetAllCategoriesNonDeleted();
			return View(new ArticleAddDto { Categories = categories });


		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid articleId)
		{
			var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
			var categories = await categoryService.GetAllCategoriesNonDeleted();
			var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
			articleUpdateDto.Categories = categories;
			return View(articleUpdateDto);
		}
		[HttpPost]
		public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
		{
			var map = mapper.Map<Article>(articleUpdateDto);
			var result = await validator.ValidateAsync(map);

			if (!result.IsValid)
			{
				var title = await articleService.UpdateArticleAsync(articleUpdateDto);

				toastNotification.AddSuccessToastMessage(Message.Article.Update(title),new ToastrOptions() { Title="işlem başarılı"});
				return RedirectToAction("Index", "Article", new { Area = "Admin" });

			}
			else
			{
				result.AddToModelState(this.ModelState);
			}
			var categories = await categoryService.GetAllCategoriesNonDeleted();
			articleUpdateDto.Categories = categories;
			return View(articleUpdateDto);
		}

		public async Task<IActionResult> Delete(Guid articleId)
		{
		var title=	await articleService.SafeDeleteArticleAsync(articleId);
			toastNotification.AddSuccessToastMessage(Message.Article.Delete(title), new ToastrOptions() { Title = "işlem başarılı" });

			return RedirectToAction("Index", "Article", new { Area = "Admin" });

		}
	}
}
