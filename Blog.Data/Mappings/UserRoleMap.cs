using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
	public class UserRoleMap : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.HasKey(r => new { r.UserId, r.RoleId });

			// Maps to the AspNetUserRoles table
			builder.ToTable("AspNetUserRoles");


			builder.HasData(
			new UserRole
			{
				UserId = Guid.Parse("DB1CDE1F-A458-428B-B0E2-AFE00C24C7B8"),
				RoleId = Guid.Parse("0E67E15F-6CAF-425B-AB91-075612DD4D16") // RoleId = "User" olmalı
			},
			new UserRole
			{
				UserId = Guid.Parse("733C1A55-8720-4BE5-AB73-A204C6F38F4B"),
				RoleId = Guid.Parse("48C1F67B-F55F-4CD8-8399-0AE2D61F5BE8"), // RoleId = "Admin" olmalı
			});
		}

		
	}
}
