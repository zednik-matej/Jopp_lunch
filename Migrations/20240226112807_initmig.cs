using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jopp_lunch.Migrations
{
    /// <inheritdoc />
    public partial class initmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "06b0096a-c509-46ba-8920-58c5341e3da7", "76999254-b221-4364-b04d-d22e6804f6b4", "employee", "employee" },
                    { "5be56830-3ba9-45d1-841c-33c180e9629a", "4741c691-ee9c-474a-98be-ce77f3ef5775", "admin", "admin" },
                    { "8451cc32-5246-45e5-89f9-5ec9bb70cb95", "49219ca3-cf23-403f-b3e9-53671e11eede", "chef", "chef" },
                    { "c57940b5-b01b-4ca8-9758-1f506bed92de", "0ebd8a81-9f8a-499a-8365-dd75ba79a533", "editor", "editor" }
                });
        }
    }
}
