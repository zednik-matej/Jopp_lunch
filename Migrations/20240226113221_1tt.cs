using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jopp_lunch.Migrations
{
    /// <inheritdoc />
    public partial class _1tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ae388d-243d-4c3c-9d3a-e49d809bb8a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ab6473f-c83b-4663-b2ac-acc800b38e20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9f7793a-b332-4abc-ac25-5cf6ae1dc018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb6a377e-e3e3-469e-94d0-cedaec052654");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "35ae388d-243d-4c3c-9d3a-e49d809bb8a5", null, "employee", "employee" },
                    { "7ab6473f-c83b-4663-b2ac-acc800b38e20", null, "chef", "chef" },
                    { "c9f7793a-b332-4abc-ac25-5cf6ae1dc018", null, "editor", "editor" },
                    { "cb6a377e-e3e3-469e-94d0-cedaec052654", null, "admin", "admin" }
                });
        }
    }
}
