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
	public class ImageMap : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.HasData(new Image
			{

				Id = Guid.Parse("4028094A-6692-442E-8952-555355BDAF74"),
				FileName = "images/vimage",
				FileType = "jpg",
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsActive = true

			},
			new Image
			{

				Id = Guid.Parse("405CEC6D-F564-4A10-B5FF-FE13757ABD60"),
				FileName = "images/vimage",
				FileType = "png",
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsActive = true

			});
		}
	}
}
