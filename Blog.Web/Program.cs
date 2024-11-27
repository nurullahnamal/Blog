using Blog.Entity.Entities;
using Blog.Data.Context;
using Blog.Data.Extensions;
using Blog.Service.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Blog.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Load custom extensions for services
			builder.Services.LoadDataLayerExtension(builder.Configuration);
			builder.Services.LoadServiceLayerExtension();
			builder.Services.AddSession();

			// Add services to the container
			builder.Services.AddControllersWithViews()
				.AddNToastNotifyToastr(new NToastNotify.ToastrOptions()
				{
					PositionClass=ToastPositions.TopRight,
					TimeOut=3400
				})
				.AddRazorRuntimeCompilation();


			builder.Services.AddIdentity<User,Role>(opt=>
			{
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
			})
				.AddRoleManager<RoleManager<Role>>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.ConfigureApplicationCookie(conf =>
			{
				conf.LoginPath = new PathString("/Admin/Auth/Login");
				conf.LogoutPath = new PathString("/Admin/Auth/Logout");
				conf.Cookie = new CookieBuilder
				{
					Name = "Blog",
					HttpOnly = true,
					SameSite = SameSiteMode.Strict,
					SecurePolicy = CookieSecurePolicy.SameAsRequest,
				};
				conf.SlidingExpiration = true;
				conf.ExpireTimeSpan=TimeSpan.FromDays(30);
				conf.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
			});


			var app = builder.Build();

			// Configure the HTTP request pipeline
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			
			app.UseSession();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			// Configure endpoints
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapAreaControllerRoute(
					name: "Admin",
					areaName: "Admin",
					pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
				);
				endpoints.MapDefaultControllerRoute();
				
			});
			app.UseNToastNotify();

			app.Run();
		}
	}
}
