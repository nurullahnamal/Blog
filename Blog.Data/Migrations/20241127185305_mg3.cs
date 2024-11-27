using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0a11921a-dbad-4f27-b116-497f6bf0adda"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b77c4964-1935-44dc-b716-aaa10b7b8793"));

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("6d2beb16-050f-4af6-8cb6-bc3bfb89f62e"), new Guid("4028094a-6692-442e-8952-555355bdaf74"), "sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 27, 21, 53, 5, 25, DateTimeKind.Local).AddTicks(7101), null, null, new Guid("4028094a-6692-442e-8952-555355bdaf74"), false, null, null, "Deneme makale ", new Guid("db1cde1f-a458-428b-b0e2-afe00c24c7b8"), 11 },
                    { new Guid("718586ba-7b38-44b7-84e9-84332f045e78"), new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), "2 sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 27, 21, 53, 5, 25, DateTimeKind.Local).AddTicks(7110), null, null, new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), false, null, null, " 2 Deneme makale ", new Guid("733c1a55-8720-4be5-ab73-a204c6f38f4b"), 11 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e67e15f-6caf-425b-ab91-075612dd4d16"),
                column: "ConcurrencyStamp",
                value: "9df6dc77-a5d3-4537-be48-f3c8066d24dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("48c1f67b-f55f-4cd8-8399-0ae2d61f5be8"),
                column: "ConcurrencyStamp",
                value: "75a96ec6-85da-49be-a4df-89485b99f77a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5957a8ce-1d49-4d12-9a41-da90b5b7a62b"),
                column: "ConcurrencyStamp",
                value: "1916c6ee-a36b-4234-b159-da137d2dff9a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("733c1a55-8720-4be5-ab73-a204c6f38f4b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a01fb9e-e726-4ccd-b7b5-a8210b123733", "AQAAAAIAAYagAAAAEK289qkHFI47hfn5VFscQPvTvoYjAMtfcEH5d+p+T92m1+DB05BuyHbCpJwWvokwow==", "a031eb51-4c7a-4fa3-9805-daf893ca3e30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("db1cde1f-a458-428b-b0e2-afe00c24c7b8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ac803c4-333a-457f-a80d-05d65f193467", "AQAAAAIAAYagAAAAEP9ci9Yqw4ifjb/C2YtoG9tQwr07xUh+93ZHR+Uc+DDsX3BpJorSPsYJdqEXlp7pmQ==", "1ed6817b-2cb1-4510-8bdc-9ad2fb320868" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                columns: new[] { "CreatedDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 11, 27, 21, 53, 5, 25, DateTimeKind.Local).AddTicks(8483), true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 27, 21, 53, 5, 25, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 27, 21, 53, 5, 25, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 27, 21, 53, 5, 25, DateTimeKind.Local).AddTicks(9649));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6d2beb16-050f-4af6-8cb6-bc3bfb89f62e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("718586ba-7b38-44b7-84e9-84332f045e78"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0a11921a-dbad-4f27-b116-497f6bf0adda"), new Guid("4028094a-6692-442e-8952-555355bdaf74"), "sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 21, 20, 23, 39, 35, DateTimeKind.Local).AddTicks(923), null, null, new Guid("4028094a-6692-442e-8952-555355bdaf74"), false, null, null, "Deneme makale ", new Guid("db1cde1f-a458-428b-b0e2-afe00c24c7b8"), 11 },
                    { new Guid("b77c4964-1935-44dc-b716-aaa10b7b8793"), new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), "2 sadsaddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "Admin", new DateTime(2024, 11, 21, 20, 23, 39, 35, DateTimeKind.Local).AddTicks(930), null, null, new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"), false, null, null, " 2 Deneme makale ", new Guid("733c1a55-8720-4be5-ab73-a204c6f38f4b"), 11 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e67e15f-6caf-425b-ab91-075612dd4d16"),
                column: "ConcurrencyStamp",
                value: "508bb49c-03be-4646-a81f-5efbcd07898d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("48c1f67b-f55f-4cd8-8399-0ae2d61f5be8"),
                column: "ConcurrencyStamp",
                value: "dedbdafc-20e1-4ad8-ada6-725446d8762b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5957a8ce-1d49-4d12-9a41-da90b5b7a62b"),
                column: "ConcurrencyStamp",
                value: "370df8e4-56cf-44cc-80da-b87af55809c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("733c1a55-8720-4be5-ab73-a204c6f38f4b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79c8d817-4c04-4b25-83b1-177f61833480", "AQAAAAIAAYagAAAAEEtnKBBAXW5b65R+gU/J7DS9dU2CBln3tnItrd/Pdab+Dc7Rsll9ZTHtmf9GA81q7Q==", "7a3676a2-d352-4e29-a0fb-64313938de19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("db1cde1f-a458-428b-b0e2-afe00c24c7b8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7417bb1-2f06-40ea-8382-52cd915736f1", "AQAAAAIAAYagAAAAED6nYvVrnGjZxeSRAf6YIRdKZL0bSSDyRerxA48HUPUGUr4jT0VQIMRzEayQETlM/g==", "86f955cc-b254-4c5d-aba1-4590d87edd52" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                columns: new[] { "CreatedDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 11, 21, 20, 23, 39, 35, DateTimeKind.Local).AddTicks(1961), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 21, 20, 23, 39, 35, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4028094a-6692-442e-8952-555355bdaf74"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 21, 20, 23, 39, 35, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("405cec6d-f564-4a10-b5ff-fe13757abd60"),
                column: "CreatedDate",
                value: new DateTime(2024, 11, 21, 20, 23, 39, 35, DateTimeKind.Local).AddTicks(2802));
        }
    }
}
