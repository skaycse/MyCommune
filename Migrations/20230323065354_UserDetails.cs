using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCommune.Migrations
{
    /// <inheritdoc />
    public partial class UserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("e0f46997-b511-43d2-8b9b-4400b29dfab8"));

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Name", "Password", "PasswordResetToken", "PasswordResetTokenExpiry" },
                values: new object[] { new Guid("21cb1ec3-3f0d-4001-8fea-93f8a4330460"), new DateTime(2023, 3, 23, 12, 23, 54, 376, DateTimeKind.Local).AddTicks(1664), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 3, 23, 12, 23, 54, 376, DateTimeKind.Local).AddTicks(1675), "Super Admin", "Commune@123", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("21cb1ec3-3f0d-4001-8fea-93f8a4330460"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Name", "Password", "PasswordResetToken", "PasswordResetTokenExpiry" },
                values: new object[] { new Guid("e0f46997-b511-43d2-8b9b-4400b29dfab8"), new DateTime(2023, 3, 4, 11, 48, 26, 44, DateTimeKind.Local).AddTicks(1457), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 3, 4, 11, 48, 26, 44, DateTimeKind.Local).AddTicks(1466), "Super Admin", "Commune@123", null, null });
        }
    }
}
