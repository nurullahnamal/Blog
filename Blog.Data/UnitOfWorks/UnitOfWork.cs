using Blog.Data.Context;
using Blog.Data.Repositories.Abstracts;
using Blog.Data.Repositories.Concretes;

namespace Blog.Data.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		AppDbContext appDbContext;

		public UnitOfWork(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}
		public async ValueTask DisposeAsync()
		{
			await appDbContext.DisposeAsync();
		}

		public int Save()
		{
			return appDbContext.SaveChanges();
			 
		}

		public async Task<int> SaveAsync()
		{
			return await appDbContext.SaveChangesAsync();
		}

		IRepository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(appDbContext);
		}
	}
}
