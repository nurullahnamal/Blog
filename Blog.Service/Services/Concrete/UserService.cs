using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Service.Helpers.Images;
using Blog.Service.Services.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{

	public class UserService : IUserService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IImageHelper imageHelper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;
		private readonly RoleManager<Role> roleManager;
		private readonly ClaimsPrincipal _user;

		public UserService(IUnitOfWork unitOfWork, IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
		{
			this.unitOfWork = unitOfWork;
			this.imageHelper = imageHelper;
			this.httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
			this.mapper = mapper;
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
		}

		public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
		{
			var map = mapper.Map<User>(userAddDto);
			map.UserName = userAddDto.Email;
			var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
			if (result.Succeeded)
			{
				var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
				await userManager.AddToRoleAsync(map, findRole.ToString());
				return result;
			}
			else
				return result;
		}

		public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
		{
			var user = await GetAppUserByIdAsync(userId);
			var result = await userManager.DeleteAsync(user);
			if (result.Succeeded)
				return (result, user.Email);
			else
				return (result, null);
		}

		public async Task<List<Role>> GetAllRolesAsync()
		{
			return await roleManager.Roles.ToListAsync();
		}

		public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
		{
			var users = await userManager.Users.ToListAsync();
			var map = mapper.Map<List<UserDto>>(users);


			foreach (var item in map)
			{
				var findUser = await userManager.FindByIdAsync(item.Id.ToString());
				var role = string.Join("", await userManager.GetRolesAsync(findUser));

				item.Role = role;
			}

			return map;
		}

		public async Task<User> GetAppUserByIdAsync(Guid userId)
		{
			return await userManager.FindByIdAsync(userId.ToString());
		}

		public async Task<string> GetUserRoleAsync(User user)
		{
			return string.Join("", await userManager.GetRolesAsync(user));
		}

		public Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
		{
			throw new NotImplementedException();
		}

		
	}
}

