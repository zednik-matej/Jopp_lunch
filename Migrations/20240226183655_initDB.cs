using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jopp_lunch.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bd7fa59-237e-47c6-9ed3-45f7d4fec8a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d2b20e7-66b0-44bf-8480-89dcbbec6cf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3c2e30f-1589-48d6-bd53-843f3e57d569");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc20e28a-d3d9-4551-a47d-b425ad9dfc41");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54072260-54b6-48c6-8ca9-6694f686b048", null, "editor", "editor" },
                    { "605a23b2-f661-446e-a9bc-17335b53ec2c", null, "chef", "chef" },
                    { "a0ea6d69-7679-44d1-b1ed-1dd972640afc", null, "admin", "admin" },
                    { "ab77b417-f5b6-496d-bf09-49a7946e0e87", null, "employee", "employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54072260-54b6-48c6-8ca9-6694f686b048");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "605a23b2-f661-446e-a9bc-17335b53ec2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0ea6d69-7679-44d1-b1ed-1dd972640afc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab77b417-f5b6-496d-bf09-49a7946e0e87");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8bd7fa59-237e-47c6-9ed3-45f7d4fec8a1", null, "chef", "chef" },
                    { "9d2b20e7-66b0-44bf-8480-89dcbbec6cf9", null, "editor", "editor" },
                    { "b3c2e30f-1589-48d6-bd53-843f3e57d569", null, "employee", "employee" },
                    { "fc20e28a-d3d9-4551-a47d-b425ad9dfc41", null, "admin", "admin" }
                });
        }
    }
}
