using AutoMapper;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;

		public UserController(UserManager<User> userManager,IMapper mapper)
		{
			this.userManager = userManager;
			this.mapper = mapper;
		}
		public async Task<IActionResult >Index()
		{
			var users = await userManager.Users.ToListAsync();
			var map=mapper.Map<List<UserDto>>(users);

			foreach (var user in map)
			{
				var findUser=await userManager.FindByIdAsync(user.Id.ToString());
				var role = string.Join("", await userManager.GetRolesAsync(findUser));

				user.Role = role;
			}
			return View(map);
		}
	}
}
