using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jopp_lunch.Migrations
{
    public partial class DelForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0717aa40-141f-44a5-9ec9-55e30a18a745");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "124c9acc-385a-451f-83b6-904a4a94fbcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3176799c-4457-4478-9217-07df8525b192");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78a5f707-b019-4c01-93c0-3972320fe829");

            migrationBuilder.DropColumn(
                name: "forma_obeda",
                table: "polevky");

            migrationBuilder.DropColumn(
                name: "forma_obeda",
                table: "obedy");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "327d4787-4072-418b-bb87-97c42f172e1a", "6090b364-9ea9-47b8-be89-60f9c6c02c52", "chef", "chef" },
                    { "36a946ac-bddd-4d83-a536-6300e114741a", "4888c1b9-cb16-4692-8bf4-9386f038e802", "employee", "employee" },
                    { "99c867cb-903d-40c9-a16f-baed337b7052", "5fd72b05-dd71-48c5-95ae-d86a773d474a", "admin", "admin" },
                    { "db9919d9-fc9e-4210-b809-2040c15cdd62", "f6502a0c-cdea-4b9f-b4de-9d9316e93954", "editor", "editor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "327d4787-4072-418b-bb87-97c42f172e1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36a946ac-bddd-4d83-a536-6300e114741a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c867cb-903d-40c9-a16f-baed337b7052");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db9919d9-fc9e-4210-b809-2040c15cdd62");

            migrationBuilder.AddColumn<string>(
                name: "forma_obeda",
                table: "polevky",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "forma_obeda",
                table: "obedy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0717aa40-141f-44a5-9ec9-55e30a18a745", "74dd3e98-ee75-4f0b-b12a-1e5b4fbf5618", "chef", "chef" },
                    { "124c9acc-385a-451f-83b6-904a4a94fbcd", "18a1a407-a7a0-4204-b88c-35d089cf6069", "editor", "editor" },
                    { "3176799c-4457-4478-9217-07df8525b192", "96bc250d-82f6-4649-a9f4-073b42a80090", "employee", "employee" },
                    { "78a5f707-b019-4c01-93c0-3972320fe829", "5ee026a3-3e37-4678-ad49-db8e3ad289b1", "admin", "admin" }
                });
        }
    }
}
