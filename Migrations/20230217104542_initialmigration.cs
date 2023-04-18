using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCommune.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastLoginDate", "Mobile", "ModifiedDate", "Name", "Password" },
                values: new object[] { new Guid("d7252490-c385-49e5-8d7c-2b58b9be54ef"), new DateTime(2023, 2, 17, 16, 15, 42, 536, DateTimeKind.Local).AddTicks(3001), "superadmin@commune.com", null, "7827020076", new DateTime(2023, 2, 17, 16, 15, 42, 536, DateTimeKind.Local).AddTicks(3013), "Super Admin", "Commune@123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
