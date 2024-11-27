using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensions
{
	public static class LogInUserExtension
	{
		public static Guid GetLogInUserId (this ClaimsPrincipal principal)
		{
			return Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
		}

		public static string GetLogInUserEmail(this ClaimsPrincipal principal)
		{
			return principal.FindFirstValue(ClaimTypes.Email);
		}
	}
}
