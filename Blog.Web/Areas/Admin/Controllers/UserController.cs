using AutoMapper;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Web.ResultMessage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly RoleManager<Role> roleManager;
		private readonly IMapper mapper;
		private readonly IToastNotification toast;

		public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IToastNotification toast)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.mapper = mapper;
			this.toast = toast;
		}
		public async Task<IActionResult> Index()
		{
			var users = await userManager.Users.ToListAsync();
			var map = mapper.Map<List<UserDto>>(users);

			foreach (var user in map)
			{
				var findUser = await userManager.FindByIdAsync(user.Id.ToString());
				var role = string.Join("", await userManager.GetRolesAsync(findUser));

				user.Role = role;
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
			var roles = await roleManager.Roles.ToListAsync();

			if (ModelState.IsValid)
			{
				map.UserName = userAddDto.Email;
				var result = await userManager.CreateAsync(map,string.IsNullOrEmpty(userAddDto.Password) ? "": userAddDto.Password);
				if (result.Succeeded)
				{
					var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
					await userManager.AddToRoleAsync(map, findRole.ToString());
					toast.AddSuccessToastMessage(Message.User.Add(userAddDto.Email), new ToastrOptions() { Title = "işlem başarılı" });
					return RedirectToAction("Index", "User", new { Area = "Admin" });

				}
				else
				{
					foreach (var error in result.Errors)
						ModelState.AddModelError("", error.Description);
					return View(new UserAddDto { Roles = roles });
				}
			}
			return View(new UserAddDto { Roles = roles });


		}
	}
}
