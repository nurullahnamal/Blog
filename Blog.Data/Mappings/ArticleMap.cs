﻿using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
	public class ArticleMap : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.HasData(new Article
			{
				Id = Guid.NewGuid(),
				Title = "Deneme makale ",
				Content = "sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd",
				ViewCount = 11,

				CategoryId = Guid.Parse("4028094A-6692-442E-8952-555355BDAF74"),
				ImageId = Guid.Parse("4028094A-6692-442E-8952-555355BDAF74"),
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsActive = true
			},
			new Article
			{
				Id = Guid.NewGuid(),
				Title = " 2 Deneme makale ",
				Content = "2 sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd",
				ViewCount = 11,
				CategoryId = Guid.Parse("405CEC6D-F564-4A10-B5FF-FE13757ABD60"),
				ImageId = Guid.Parse("405CEC6D-F564-4A10-B5FF-FE13757ABD60"),
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsActive = true
			});
		}
	}
}
