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
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(new Category
			{

				Id = Guid.Parse("4028094A-6692-442E-8952-555355BDAF74"),
				CategoryName = "Asp net core",
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			},
			new Category
			{

				Id = Guid.Parse("405CEC6D-F564-4A10-B5FF-FE13757ABD60"),
				CategoryName = "2 Visual Studio",
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsDeleted = false

			});
		}
	}
}
