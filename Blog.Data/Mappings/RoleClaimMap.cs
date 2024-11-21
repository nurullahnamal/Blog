using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
	public class RoleClaimMap : IEntityTypeConfiguration<RoleClaim>
	{
		public void Configure(EntityTypeBuilder<RoleClaim> builder)
		{
			 builder.HasKey(rc => rc.Id);

			// Maps to the AspNetRoleClaims table
			builder.ToTable("AspNetRoleClaims");
		}
	}
}
