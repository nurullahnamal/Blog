﻿using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Helpers.Images;
using Blog.Service.Services.Abstractions;
using Blog.Web.ResultMessage;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class UserController : Controller
	{
		private readonly IUserService userService;
		private readonly IValidator<User> validator;
		private readonly IToastNotification toast;
		private readonly IMapper mapper;

		public UserController(IUserService userService, IUnitOfWork unitOfWork, IImageHelper imageHelper, IValidator<User> validator, IToastNotification toast, IMapper mapper)
		{
			this.userService = userService;
			this.validator = validator;
			this.toast = toast;
			this.mapper = mapper;
		}
		public async Task<IActionResult> Index()
		{
			var result = await userService.GetAllUsersWithRoleAsync();

			return View(result);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var roles = await userService.GetAllRolesAsync();
			return View(new UserAddDto { Roles = roles });
		}
		[HttpPost]
		public async Task<IActionResult> Add(UserAddDto userAddDto)
		{
			var map = mapper.Map<Entity.Entities.User>(userAddDto);
			var validation = await validator.ValidateAsync(map);
			var roles = await userService.GetAllRolesAsync();

			if (ModelState.IsValid)
			{
				var result = await userService.CreateUserAsync(userAddDto);
				if (result.Succeeded)
				{
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
			var user = await userService.GetAppUserByIdAsync(userId);

			var roles = await userService.GetAllRolesAsync();

			var map = mapper.Map<UserUpdateDto>(user);
			map.Roles = roles;
			return View(map);
		}
		[HttpPost]
		public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
		{
			var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);

			if (user != null)
			{
				var roles = await userService.GetAllRolesAsync();
				if (ModelState.IsValid)
				{
					var map = mapper.Map(userUpdateDto, user);
					var validation = await validator.ValidateAsync(map);

					if (validation.IsValid)
					{
						user.UserName = userUpdateDto.Email;
						user.SecurityStamp = Guid.NewGuid().ToString();
						var result = await userService.UpdateUserAsync(userUpdateDto);
						if (result.Succeeded)
						{
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
			var result = await userService.DeleteUserAsync(userId);


			if (result.identityResult.Succeeded)
			{
				toast.AddSuccessToastMessage(Message.User.Delete(result.email), new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "User", new { Area = "Admin" });
			}
			else
			{
				result.identityResult.AddToIdentityModelState(this.ModelState);
			}
			return NotFound();
		}

		[HttpGet]
		public async Task<IActionResult> Profile()
		{
			var profile = await userService.GetUserProfileAsync();

			return View(profile);
		}

		[HttpPost]
		public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
		{
			if (ModelState.IsValid)
			{
				var result = await userService.UserProfileUpdateAsync(userProfileDto);
				if (result)
				{
					toast.AddSuccessToastMessage("Profil güncelleme işlemi basarılı ile tamamlandı  ", new ToastrOptions { Title = "işlem başarılı " });
					return RedirectToAction("Index", "User", new { Area = "Admin" });

				}
				else
				{
					var profile = await userService.GetUserProfileAsync();
					toast.AddErrorToastMessage("Profil güncelleme işlemi başarısız  ", new ToastrOptions { Title = "işlem başarısız " });
					return View(profile);
				}
			}
			else
			{
				return NotFound();

			}


		}
	}
}
