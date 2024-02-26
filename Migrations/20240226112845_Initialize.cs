using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jopp_lunch.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4286e654-cc50-4733-a676-162bd65cef7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a44d8f64-792f-48ef-b0b4-d58bed46009b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4f91960-1818-4f80-b4a2-656de2539378");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfebb937-7a1c-4099-98bc-fbd454bc25da");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "4286e654-cc50-4733-a676-162bd65cef7d", null, "employee", "employee" },
                    { "a44d8f64-792f-48ef-b0b4-d58bed46009b", null, "chef", "chef" },
                    { "d4f91960-1818-4f80-b4a2-656de2539378", null, "editor", "editor" },
                    { "dfebb937-7a1c-4099-98bc-fbd454bc25da", null, "admin", "admin" }
                });
        }
    }
}
