using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstractions
{
	public interface IUserService
	{
		Task<List<UserDto>> GetAllUsersWithRoleAsync();
		Task<List<Role>>GetAllRolesAsync();
		Task<IdentityResult>CreateUserAsync(UserAddDto userAddDto);
		Task<IdentityResult>UpdateUserAsync(UserUpdateDto userUpdateDto);
		Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
		Task<User> GetAppUserByIdAsync(Guid userId);
		Task<string>GetUserRoleAsync(User user);
		Task<UserProfileDto> GetUserProfileAsync();
		Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);
	}
}
