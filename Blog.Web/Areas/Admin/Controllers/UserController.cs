using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Entity.Enum;
using Blog.Service.Extensions;
using Blog.Service.Helpers.Images;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using Blog.Web.ResultMessage;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using static Blog.Web.ResultMessage.Message;
using User = Blog.Entity.Entities.User;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class UserController : Controller
	{
		private readonly UserManager<Entity.Entities.User> userManager;
		private readonly IUserService userService;
		private readonly IUnitOfWork unitOfWork;
		private readonly RoleManager<Role> roleManager;
		private readonly IImageHelper imageHelper;
		private readonly IValidator<Entity.Entities.User> validator;
		private readonly IToastNotification toast;
		private readonly SignInManager<Entity.Entities.User> signInManager;
		private readonly IMapper mapper;

		public UserController(UserManager<Entity.Entities.User> userManager, IUserService userService, IUnitOfWork unitOfWork, RoleManager<Role> roleManager, IImageHelper imageHelper, IValidator<User> validator, IToastNotification toast, SignInManager<User> signInManager, IMapper mapper)
		{
			this.userManager = userManager;
			this.userService = userService;
			this.unitOfWork = unitOfWork;
			this.roleManager = roleManager;
			this.imageHelper = imageHelper;
			this.validator = validator;
			this.toast = toast;
			this.signInManager = signInManager;
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
			var user = await userManager.GetUserAsync(HttpContext.User);
			var getImage = await unitOfWork.GetRepository<Entity.Entities.User>().GetAsync(x => x.Id == user.Id, x => x.Image);
			var map = mapper.Map<UserProfileDto>(user);
			map.Image.FileName = getImage.Image.FileName;

			return View(map);
		}
		[HttpPost]
		public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
		{
			var user = await userManager.GetUserAsync(HttpContext.User);

			if (ModelState.IsValid)
			{
				var isVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
				if (isVerified && userProfileDto.NewPassword != null)
				{

					var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
					if (result.Succeeded)
					{

						await userManager.UpdateSecurityStampAsync(user);
						await signInManager.SignOutAsync();
						await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

						user.FirstName = userProfileDto.FirstName;
						user.LastName = userProfileDto.LastName;
						user.PhoneNumber = userProfileDto.PhoneNumber;

						var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName},{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
						Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, user.Email);
						await unitOfWork.GetRepository<Image>().AddAsync(image);

						user.ImageId = image.Id;

						await userManager.UpdateAsync(user);
						await unitOfWork.SaveAsync();


						toast.AddSuccessToastMessage("Şifreniz ve bilgileriniz başarılı olarak degiştirildi");
						return View();
					}
					else
					{
						result.AddToIdentityModelState(ModelState); return View();
					}
				}
				else if (isVerified)
				{
					await userManager.UpdateSecurityStampAsync(user);
					user.FirstName = userProfileDto.FirstName;
					user.LastName = userProfileDto.LastName;
					user.PhoneNumber = userProfileDto.PhoneNumber;
					var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName},{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
					Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, user.Email);
					await unitOfWork.GetRepository<Image>().AddAsync(image);

					user.ImageId = image.Id;


					await unitOfWork.SaveAsync();

					await userManager.UpdateAsync(user);

					toast.AddSuccessToastMessage("Şifreniz ve bilgileriniz başarılı olarak degiştirildi");
					return View();
				}
				else
				{
					toast.AddSuccessToastMessage("Şifreniz ve bilgileriniz güncellenirken bir  hata olustu..."); return View();


				}
			}
			return View();

		}
	}
}
