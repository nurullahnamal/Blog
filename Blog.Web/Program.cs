using Blog.Data.Context;
using Blog.Data.Extensions;
using Blog.Web.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Load custom extensions for services
			builder.Services.LoadDataLayerExtension(builder.Configuration);
			builder.Services.ServiceLayerExtension();

			// Add services to the container
			builder.Services.AddControllersWithViews();

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

			app.UseRouting();

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

			app.Run();
		}
	}
}
