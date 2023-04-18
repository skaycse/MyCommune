using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCommune.Migrations
{
    /// <inheritdoc />
    public partial class alterusertablenormalisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_users_UserId",
                table: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("21cb1ec3-3f0d-4001-8fea-93f8a4330460"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "users");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "user_details");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_UserId",
                table: "user_details",
                newName: "IX_user_details_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_details",
                table: "user_details",
                column: "Id");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Password", "PasswordResetToken", "PasswordResetTokenExpiry" },
                values: new object[] { new Guid("96d931b0-8955-440e-9e46-c5c3a3f3a1a1"), new DateTime(2023, 3, 24, 15, 38, 17, 497, DateTimeKind.Local).AddTicks(6567), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 3, 24, 15, 38, 17, 497, DateTimeKind.Local).AddTicks(6577), "Commune@123", null, null });

            migrationBuilder.InsertData(
                table: "user_details",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, "Society", "Test", "Test", new Guid("96d931b0-8955-440e-9e46-c5c3a3f3a1a1") });

            migrationBuilder.AddForeignKey(
                name: "FK_user_details_users_UserId",
                table: "user_details",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_details_users_UserId",
                table: "user_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_details",
                table: "user_details");

            migrationBuilder.DeleteData(
                table: "user_details",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("96d931b0-8955-440e-9e46-c5c3a3f3a1a1"));

            migrationBuilder.RenameTable(
                name: "user_details",
                newName: "UserDetails");

            migrationBuilder.RenameIndex(
                name: "IX_user_details_UserId",
                table: "UserDetails",
                newName: "IX_UserDetails_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Name", "Password", "PasswordResetToken", "PasswordResetTokenExpiry" },
                values: new object[] { new Guid("21cb1ec3-3f0d-4001-8fea-93f8a4330460"), new DateTime(2023, 3, 23, 12, 23, 54, 376, DateTimeKind.Local).AddTicks(1664), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 3, 23, 12, 23, 54, 376, DateTimeKind.Local).AddTicks(1675), "Super Admin", "Commune@123", null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_users_UserId",
                table: "UserDetails",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
