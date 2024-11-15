﻿// <auto-generated />
using System;
using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241114145513_seeddata")]
    partial class seeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blog.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2d40705e-bb16-453e-8145-f2c558292112"),
                            CategoryId = new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                            Content = "sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(8781),
                            ImageId = new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                            IsActive = true,
                            Title = "Deneme makale ",
                            ViewCount = 11
                        },
                        new
                        {
                            Id = new Guid("6bbea20f-4560-4f55-b4c4-7f85ef2742d8"),
                            CategoryId = new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                            Content = "2 sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(8787),
                            ImageId = new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                            IsActive = true,
                            Title = " 2 Deneme makale ",
                            ViewCount = 11
                        });
                });

            modelBuilder.Entity("Blog.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                            CategoryName = "Asp net core",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(9762),
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                            CategoryName = "2 Visual Studio",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(9765),
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Blog.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 11, 14, 17, 55, 13, 199, DateTimeKind.Local).AddTicks(574),
                            FileName = "images/vimage",
                            FileType = "jpg",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 11, 14, 17, 55, 13, 199, DateTimeKind.Local).AddTicks(584),
                            FileName = "images/vimage",
                            FileType = "png",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Blog.Entity.Entities.Article", b =>
                {
                    b.HasOne("Blog.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Blog.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Blog.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
