using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jopp_lunch.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05b4125d-a903-4d63-930a-59ab66a511fb", "37538310-76da-4383-a1f2-b6e8bedaba35", "chef", "chef" },
                    { "2544a343-e82d-4dc7-9e65-0dd327f88337", "974dc78a-8eec-42f6-b92f-0e109f180229", "editor", "editor" },
                    { "2a6b22d2-3c9b-4f62-822f-843c14891ecf", "550cd939-8571-464e-9a8e-1e5c2ac432a8", "employee", "employee" },
                    { "66dcb6ae-a021-41af-bf59-810ce1d3a903", "4fe110ee-9979-4923-aa3b-b3eafe066b20", "admin", "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05b4125d-a903-4d63-930a-59ab66a511fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2544a343-e82d-4dc7-9e65-0dd327f88337");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a6b22d2-3c9b-4f62-822f-843c14891ecf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66dcb6ae-a021-41af-bf59-810ce1d3a903");
        }
    }
}
