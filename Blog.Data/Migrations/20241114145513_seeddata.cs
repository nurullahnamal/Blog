using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsActive", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("4028094a-6692-442e-8952-555355bdaf74"), "Asp net core", "Admin", new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(9762), null, null, true, null, null },
                    { new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), "2 Visual Studio", "Admin", new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(9765), null, null, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("4028094a-6692-442e-8952-555355bdaf74"), "Admin", new DateTime(2024, 11, 14, 17, 55, 13, 199, DateTimeKind.Local).AddTicks(574), null, null, "images/vimage", "jpg", true, null, null },
                    { new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), "Admin", new DateTime(2024, 11, 14, 17, 55, 13, 199, DateTimeKind.Local).AddTicks(584), null, null, "images/vimage", "png", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsActive", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2d40705e-bb16-453e-8145-f2c558292112"), new Guid("4028094a-6692-442e-8952-555355bdaf74"), "sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(8781), null, null, new Guid("4028094a-6692-442e-8952-555355bdaf74"), true, null, null, "Deneme makale ", 11 },
                    { new Guid("6bbea20f-4560-4f55-b4c4-7f85ef2742d8"), new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), "2 sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(8787), null, null, new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), true, null, null, " 2 Deneme makale ", 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2d40705e-bb16-453e-8145-f2c558292112"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6bbea20f-4560-4f55-b4c4-7f85ef2742d8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"));
        }
    }
}
