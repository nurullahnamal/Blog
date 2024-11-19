
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensions
{
	public static class ServiceLayerExtensions
	{
		public static IServiceCollection ServiceLayerExtension(this IServiceCollection services)
		{
			var assemly = Assembly.GetExecutingAssembly();

			services.AddScoped<IArticleService, ArticleService>();

			services.AddAutoMapper(assemly);
			return services;
		}
	}
}
