using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class HomeController : Controller
	{

		private readonly IArticleService articleService;
		private readonly IDashboardService dashboardService;

		public HomeController(IArticleService articleService,IDashboardService dashboardService)
		{
			this.articleService = articleService;
			this.dashboardService = dashboardService;
		}
		public async Task<IActionResult> Index()
		{
			var artices = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
			
			return View(artices);
		}
		[HttpGet]
		public async Task<IActionResult> YearlyArticleCounts()
		{
			var count = await dashboardService.GetYearyArticleCounts();
			return Json(JsonConvert.SerializeObject(count));
		}
	}
}
