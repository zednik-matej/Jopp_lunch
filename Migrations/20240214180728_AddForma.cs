using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jopp_lunch.Migrations
{
    public partial class AddForma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "forma",
                table: "vybery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06b0096a-c509-46ba-8920-58c5341e3da7", "76999254-b221-4364-b04d-d22e6804f6b4", "employee", "employee" },
                    { "5be56830-3ba9-45d1-841c-33c180e9629a", "4741c691-ee9c-474a-98be-ce77f3ef5775", "admin", "admin" },
                    { "8451cc32-5246-45e5-89f9-5ec9bb70cb95", "49219ca3-cf23-403f-b3e9-53671e11eede", "chef", "chef" },
                    { "c57940b5-b01b-4ca8-9758-1f506bed92de", "0ebd8a81-9f8a-499a-8365-dd75ba79a533", "editor", "editor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06b0096a-c509-46ba-8920-58c5341e3da7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5be56830-3ba9-45d1-841c-33c180e9629a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8451cc32-5246-45e5-89f9-5ec9bb70cb95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c57940b5-b01b-4ca8-9758-1f506bed92de");

            migrationBuilder.DropColumn(
                name: "forma",
                table: "vybery");

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
    }
}
