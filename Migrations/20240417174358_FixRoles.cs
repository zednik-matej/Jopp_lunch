using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jopp_lunch.Migrations
{
    /// <inheritdoc />
    public partial class FixRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f3290a0-89e7-498b-8a8f-3e74e238c39e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d57b7c9f-8fbb-4f81-92a7-4bf27b2833fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9415606-d4ee-4a0c-af5a-c512b88e2ab6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd2b152c-297b-4e2a-8f2c-f5df1b7688f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39cf23f1-7b20-4771-898c-53776b1578d2", null, "editor", "editor" },
                    { "64611ccc-e465-4301-94c9-50eec52d1e41", null, "employee", "employee" },
                    { "c38fef13-38a9-428b-8a5d-5dc6f8098b14", null, "admin", "admin" },
                    { "e361c785-5309-4bd1-90ef-856e22dff343", null, "chef", "chef" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39cf23f1-7b20-4771-898c-53776b1578d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64611ccc-e465-4301-94c9-50eec52d1e41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c38fef13-38a9-428b-8a5d-5dc6f8098b14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e361c785-5309-4bd1-90ef-856e22dff343");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f3290a0-89e7-498b-8a8f-3e74e238c39e", null, "employee", "employee" },
                    { "d57b7c9f-8fbb-4f81-92a7-4bf27b2833fa", null, "admin", "admin" },
                    { "d9415606-d4ee-4a0c-af5a-c512b88e2ab6", null, "chef", "chef" },
                    { "dd2b152c-297b-4e2a-8f2c-f5df1b7688f5", null, "editor", "editor" }
                });
        }
    }
}
