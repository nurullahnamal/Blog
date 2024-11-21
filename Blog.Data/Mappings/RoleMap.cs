using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
	public class RoleMap : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(r => r.Id);

			// Index for "normalized" role name to allow efficient lookups
			builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

			// Maps to the AspNetRoles table
			builder.ToTable("AspNetRoles");

			// A concurrency token for use with the optimistic concurrency checking
			builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

			// Limit the size of columns to use efficient database types
			builder.Property(u => u.Name).HasMaxLength(256);
			builder.Property(u => u.NormalizedName).HasMaxLength(256);

			// The relationships between Role and other entity types
			// Note that these relationships are configured with no navigation properties

			// Each Role can have many entries in the UserRole join table
			builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

			// Each Role can have many associated RoleClaims
			builder.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();


			builder.HasData(
				new Role
				{
					Id = Guid.Parse("0E67E15F-6CAF-425B-AB91-075612DD4D16"),
					Name = "RootAdmin",
					NormalizedName = "ROOTADMIN",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},

				new Role
				{
					Id = Guid.Parse("48C1F67B-F55F-4CD8-8399-0AE2D61F5BE8"),
					Name = "Admin",
					NormalizedName = "ADMIN",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
				new Role
				{
					Id = Guid.Parse("5957A8CE-1D49-4D12-9A41-DA90B5B7A62B"),
					Name = "User",
					NormalizedName = "USER",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				}
		);
		}

	}
}
