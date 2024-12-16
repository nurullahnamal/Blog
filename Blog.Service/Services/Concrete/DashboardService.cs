﻿using Blog.Data.UnitOfWorks;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
	public class DashboardService : IDashboardService
	{
		private readonly IUnitOfWork unitOfWork;

		public DashboardService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<List<int>> GetYearyArticleCounts()
		{
			var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);
			var startDate = DateTime.Now.Date;

			startDate = new DateTime(startDate.Year, 1, 1);

			List<int> datas = new();

			for (int i = 1; i <= 12; i++)
			{
				var startedDate=new DateTime(startDate.Year, i, 1);
				var endedDate=startedDate.Date;	
				var data =articles.Where(x=>x.CreatedDate>=startDate && x.CreatedDate<=endedDate).Count();
				datas.Add(data);
			}
			return datas;
		}
	}
}

