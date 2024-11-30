using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Categories;
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
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;
		private readonly ClaimsPrincipal principal1;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ClaimsPrincipal _user;

		public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ClaimsPrincipal principal,IHttpContextAccessor httpContextAccessor)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
		}
		public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
		{
			

			var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
			var map = mapper.Map<List<CategoryDto>>(categories);

			return map;
		}

		public async Task<string> CreateCategoryAsync(CategoryAddDto categoryAddDto)
		{
			var userEmail = _user.GetLogInUserEmail();
			Category category = new(categoryAddDto.Name,userEmail);
			await unitOfWork.GetRepository<Category>().AddAsync(category);
			await unitOfWork.SaveAsync();
			return category.Name;
		}

	}
}
