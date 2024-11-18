using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Conextension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2d40705e-bb16-453e-8145-f2c558292112"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6bbea20f-4560-4f55-b4c4-7f85ef2742d8"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsActive", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("c607bdb4-50a7-4109-87cb-1bcbab40fdd8"), new Guid("4028094a-6692-442e-8952-555355bdaf74"), "sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 18, 19, 3, 42, 741, DateTimeKind.Local).AddTicks(3652), null, null, new Guid("4028094a-6692-442e-8952-555355bdaf74"), true, null, null, "Deneme makale ", 11 },
                    { new Guid("f76d1ab5-39ce-4d74-aa41-a9e66b8ab28e"), new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), "2 sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 18, 19, 3, 42, 741, DateTimeKind.Local).AddTicks(3657), null, null, new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), true, null, null, " 2 Deneme makale ", 11 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 19, 3, 42, 741, DateTimeKind.Local).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 19, 3, 42, 741, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 19, 3, 42, 741, DateTimeKind.Local).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 19, 3, 42, 741, DateTimeKind.Local).AddTicks(5465));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c607bdb4-50a7-4109-87cb-1bcbab40fdd8"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f76d1ab5-39ce-4d74-aa41-a9e66b8ab28e"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsActive", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2d40705e-bb16-453e-8145-f2c558292112"), new Guid("4028094a-6692-442e-8952-555355bdaf74"), "sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(8781), null, null, new Guid("4028094a-6692-442e-8952-555355bdaf74"), true, null, null, "Deneme makale ", 11 },
                    { new Guid("6bbea20f-4560-4f55-b4c4-7f85ef2742d8"), new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), "2 sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(8787), null, null, new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), true, null, null, " 2 Deneme makale ", 11 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 14, 17, 55, 13, 198, DateTimeKind.Local).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 14, 17, 55, 13, 199, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 14, 17, 55, 13, 199, DateTimeKind.Local).AddTicks(584));
        }
    }
}
