using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jopp_lunch.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "vychozi_VMcislo_VM",
                table: "uzivatele",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_uzivatele_vychozi_VMcislo_VM",
                table: "uzivatele",
                column: "vychozi_VMcislo_VM");

            migrationBuilder.AddForeignKey(
                name: "FK_uzivatele_vyjedni_mista_vychozi_VMcislo_VM",
                table: "uzivatele",
                column: "vychozi_VMcislo_VM",
                principalTable: "vyjedni_mista",
                principalColumn: "cislo_VM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uzivatele_vyjedni_mista_vychozi_VMcislo_VM",
                table: "uzivatele");

            migrationBuilder.DropIndex(
                name: "IX_uzivatele_vychozi_VMcislo_VM",
                table: "uzivatele");

            migrationBuilder.DropColumn(
                name: "vychozi_VMcislo_VM",
                table: "uzivatele");

        }
    }
}
