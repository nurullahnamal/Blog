using Blog.Data.Repositories.Abstracts;
using Blog.Data.Repositories.Concretes;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;

namespace Blog.Web.Extensions
{
	public static class ServiceLayerExtensions
	{
		public static IServiceCollection ServiceLayerExtension(this IServiceCollection services)
		{
			services.AddScoped<IArticleService,ArticleService>();
			return services;
		}
	}
}
