using AutoMapper;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Web.ResultMessage;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly RoleManager<Role> roleManager;
		private readonly IValidator<User> validator;
		private readonly IToastNotification toast;
		private readonly IMapper mapper;

		public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IValidator<User> validator, IToastNotification toast, IMapper mapper)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.validator = validator;
			this.toast = toast;
			this.mapper = mapper;
		}
		public async Task<IActionResult> Index()
		{
			var users = await userManager.Users.ToListAsync();
			var map = mapper.Map<List<UserDto>>(users);


			foreach (var item in map)
			{
				var findUser = await userManager.FindByIdAsync(item.Id.ToString());
				var role = string.Join("", await userManager.GetRolesAsync(findUser));

				item.Role = role;
			}

			return View(map);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var roles = await roleManager.Roles.ToListAsync();
			return View(new UserAddDto { Roles = roles });
		}
		[HttpPost]
		public async Task<IActionResult> Add(UserAddDto userAddDto)
		{
			var map = mapper.Map<User>(userAddDto);
			var validation = await validator.ValidateAsync(map);
			var roles = await roleManager.Roles.ToListAsync();

			if (ModelState.IsValid)
			{
				map.UserName = userAddDto.Email;
				var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
				if (result.Succeeded)
				{
					var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
					await userManager.AddToRoleAsync(map, findRole.ToString());
					toast.AddSuccessToastMessage(Message.User.Add(userAddDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
					return RedirectToAction("Index", "User", new { Area = "Admin" });
				}
				else
				{
					result.AddToIdentityModelState(this.ModelState);
					validation.AddToModelState(this.ModelState);
					return View(new UserAddDto { Roles = roles });

				}
			}
			return View(new UserAddDto { Roles = roles });
		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid userId)
		{
			var user = await userManager.FindByIdAsync(userId.ToString());

			var roles = await roleManager.Roles.ToListAsync();

			var map = mapper.Map<UserUpdateDto>(user);
			map.Roles = roles;
			return View(map);
		}
		[HttpPost]
		public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
		{
			var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());

			if (user != null)
			{
				var userRole = string.Join("", await userManager.GetRolesAsync(user));
				var roles = await roleManager.Roles.ToListAsync();
				if (ModelState.IsValid)
				{
					var map = mapper.Map(userUpdateDto, user);
					var validation = await validator.ValidateAsync(map);

					if (validation.IsValid)
					{
						user.UserName = userUpdateDto.Email;
						user.SecurityStamp = Guid.NewGuid().ToString();
						var result = await userManager.UpdateAsync(user);
						if (result.Succeeded)
						{
							await userManager.RemoveFromRoleAsync(user, userRole);
							var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
							await userManager.AddToRoleAsync(user, findRole.Name);
							toast.AddSuccessToastMessage(Message.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
							return RedirectToAction("Index", "User", new { Area = "Admin" });
						}
						else
						{
							result.AddToIdentityModelState(this.ModelState);
							return View(new UserUpdateDto { Roles = roles });
						}
					}
					else
					{
						validation.AddToModelState(this.ModelState);
						return View(new UserUpdateDto { Roles = roles });
					}


				}
			}
			return NotFound();
		}
		public async Task<IActionResult> Delete(Guid userId)
		{
			var user = await userManager.FindByIdAsync(userId.ToString());

			var result = await userManager.DeleteAsync(user);

			if (result.Succeeded)
			{
				toast.AddSuccessToastMessage(Message.User.Delete(user.Email), new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "User", new { Area = "Admin" });
			}
			else
			{
				result.AddToIdentityModelState(this.ModelState);
			}
			return NotFound();
		}
	}
}
