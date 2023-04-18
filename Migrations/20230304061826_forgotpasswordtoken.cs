using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCommune.Migrations
{
    /// <inheritdoc />
    public partial class forgotpasswordtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("2ef660f2-a45c-4db5-9af8-387e86e4fe10"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "users",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetTokenExpiry",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Name", "Password", "PasswordResetToken", "PasswordResetTokenExpiry" },
                values: new object[] { new Guid("e0f46997-b511-43d2-8b9b-4400b29dfab8"), new DateTime(2023, 3, 4, 11, 48, 26, 44, DateTimeKind.Local).AddTicks(1457), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 3, 4, 11, 48, 26, 44, DateTimeKind.Local).AddTicks(1466), "Super Admin", "Commune@123", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("e0f46997-b511-43d2-8b9b-4400b29dfab8"));

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpiry",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Name", "Password" },
                values: new object[] { new Guid("2ef660f2-a45c-4db5-9af8-387e86e4fe10"), new DateTime(2023, 2, 28, 23, 2, 21, 931, DateTimeKind.Local).AddTicks(5381), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 2, 28, 23, 2, 21, 931, DateTimeKind.Local).AddTicks(5394), "Super Admin", "Commune@123" });
        }
    }
}
