using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jopp_lunch.Migrations
{
    public partial class UserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens");
            migrationBuilder.DropPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins");
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

            migrationBuilder.DropColumn(
                name: "role",
                table: "uzivatele");

            migrationBuilder.DropColumn(
                name: "vychozi_forma",
                table: "uzivatele");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens", new string[] { "UserId", "LoginProvider", "Name" });
            migrationBuilder.AddPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins", new string[] { "LoginProvider", "ProviderKey" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "uzivatele",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "vychozi_forma",
                table: "uzivatele",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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
    }
}
