using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
	public class UserTokenMap : IEntityTypeConfiguration<UserToken>
	{
		public void Configure(EntityTypeBuilder<UserToken> builder)
		{
			builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

			// Limit the size of the composite key columns due to common DB restrictions
			builder.Property(t => t.LoginProvider).HasMaxLength(400);
			builder.Property(t => t.Name).HasMaxLength(400);

			// Maps to the AspNetUserTokens table
			builder.ToTable("AspNetUserTokens");
		}
	}
}
