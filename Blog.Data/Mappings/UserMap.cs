using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)

		{
			builder.HasKey(u => u.Id);

			// Indexes for "normalized" username and email, to allow efficient lookups
			builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
			builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

			// Maps to the AspNetUsers tabuilderle
			builder.ToTable("AspNetUsers");

			// A concurrency token for use with the optimistic concurrency checking
			builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

			// Limit the size of columns to use efficient databuilderase types
			builder.Property(u => u.UserName).HasMaxLength(256);
			builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
			builder.Property(u => u.Email).HasMaxLength(256);
			builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

			// The relationships builderetween User and other entity types
			// Note that these relationships are configured with no navigation properties

			// Each User can have many UserClaims
			builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

			// Each User can have many UserLogins
			builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

			// Each User can have many UserTokens
			builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

			// Each User can have many entries in the UserRole join tabuilderle
			builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

			var rootAdmin = new User
			{
				Id = Guid.Parse("DB1CDE1F-A458-428B-B0E2-AFE00C24C7B8"),
				UserName = "rootadmin@gmail.com",
				NormalizedUserName = "ROOTADMIN@GMAIL.COM",
				Email = "rootadmin@gmail.com",
				NormalizedEmail = "ROOTADMIN@GMAIL.COM",
				PhoneNumber = "+9056665585",
				FirstName = "Nurullah",
				LastName = "Namal",
				PhoneNumberConfirmed = true,
				EmailConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString(),
				ImageId= Guid.Parse("4028094A-6692-442E-8952-555355BDAF74"),
			};

			rootAdmin.PasswordHash = CreatePasswordHash(rootAdmin, "123456");




			var admin = new User
			{
				Id = Guid.Parse("733C1A55-8720-4BE5-AB73-A204C6F38F4B"),
				UserName = "admin@gmail.com",
				NormalizedUserName = "ADMIN@GMAIL.COM",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				PhoneNumber = "+90566655875",
				FirstName = "Mete",
				LastName = "Namal",
				PhoneNumberConfirmed = false,
				EmailConfirmed = false,
				SecurityStamp = Guid.NewGuid().ToString(),
				ImageId = Guid.Parse("405CEC6D-F564-4A10-B5FF-FE13757ABD60"),

			};

			admin.PasswordHash = CreatePasswordHash(admin, "123456");


			builder.HasData(rootAdmin,admin);
		}
		private string CreatePasswordHash(User user,string passwoed)
		{
			var passwordHasher = new PasswordHasher<User>();
			return passwordHasher.HashPassword(user, passwoed);
		}

	}
}
