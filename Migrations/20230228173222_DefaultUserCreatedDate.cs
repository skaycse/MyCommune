using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCommune.Migrations
{
    /// <inheritdoc />
    public partial class DefaultUserCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("d7252490-c385-49e5-8d7c-2b58b9be54ef"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Name", "Password" },
                values: new object[] { new Guid("2ef660f2-a45c-4db5-9af8-387e86e4fe10"), new DateTime(2023, 2, 28, 23, 2, 21, 931, DateTimeKind.Local).AddTicks(5381), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 2, 28, 23, 2, 21, 931, DateTimeKind.Local).AddTicks(5394), "Super Admin", "Commune@123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("2ef660f2-a45c-4db5-9af8-387e86e4fe10"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Name", "Password" },
                values: new object[] { new Guid("d7252490-c385-49e5-8d7c-2b58b9be54ef"), new DateTime(2023, 2, 17, 16, 15, 42, 536, DateTimeKind.Local).AddTicks(3001), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 2, 17, 16, 15, 42, 536, DateTimeKind.Local).AddTicks(3013), "Super Admin", "Commune@123" });
        }
    }
}
