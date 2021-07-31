using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LEARNING.Migrations
{
    public partial class fdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_infoTitres",
                table: "infoTitres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "infoTitres");

            migrationBuilder.AddColumn<int>(
                name: "Id_info",
                table: "infoTitres",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_infoTitres",
                table: "infoTitres",
                column: "Id_info");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_infoTitres",
                table: "infoTitres");

            migrationBuilder.DropColumn(
                name: "Id_info",
                table: "infoTitres");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "infoTitres",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_infoTitres",
                table: "infoTitres",
                column: "Id");
        }
    }
}
