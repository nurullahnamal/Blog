using Blog.Entity.Entities;
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
				IsDeleted = false,
				UserId = Guid.Parse("DB1CDE1F-A458-428B-B0E2-AFE00C24C7B8")

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
				IsDeleted = false,

				UserId = Guid.Parse("733C1A55-8720-4BE5-AB73-A204C6F38F4B"),
			});
		}
	}
}
