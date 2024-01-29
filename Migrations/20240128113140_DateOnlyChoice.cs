using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jopp_lunch.Migrations
{
    public partial class DateOnlyChoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "817cbdea-6e90-4fda-acca-39bded109c62", "4a5796bc-6142-4833-ad4a-d3cbe7d16ca3", "admin", "admin" },
                    { "845c0230-bf16-418b-89ec-94e47e2dda2a", "280ade79-375a-4a5c-be39-0fd7d838a5cc", "employee", "employee" },
                    { "9622e49a-8085-45f8-b7b7-dd0d9f28ccaa", "f85bfb90-b18d-4c4a-82f5-a0cb709730a9", "editor", "editor" },
                    { "f12f7258-dd57-43e8-bacd-96ca127abb5d", "ea35fd43-c78b-4434-9071-93e991b4962e", "chef", "chef" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "817cbdea-6e90-4fda-acca-39bded109c62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "845c0230-bf16-418b-89ec-94e47e2dda2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9622e49a-8085-45f8-b7b7-dd0d9f28ccaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f12f7258-dd57-43e8-bacd-96ca127abb5d");

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
    }
}
