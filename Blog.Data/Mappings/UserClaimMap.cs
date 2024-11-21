using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
	public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
	{
		public void Configure(EntityTypeBuilder<UserClaim> builder)
		{
			// Primary key
			builder.HasKey(uc => uc.Id);

			// Maps to the AspNetUserClaims table
			builder.ToTable("AspNetUserClaims");
		}
	}
}
