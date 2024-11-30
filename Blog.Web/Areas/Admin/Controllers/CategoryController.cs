using Blog.Entity.DTOs.Categories;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}
		public async Task< IActionResult >Index()
		{
			var categoriesList=await categoryService.GetAllCategoriesNonDeleted();
			return View(categoriesList);
		}


		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(CategoryAddDto categoryAddDto)
		{

			return View();
		}
	}
}
