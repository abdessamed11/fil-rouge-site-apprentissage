using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LEARNING.Migrations
{
    public partial class fdhhg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTitre_tblFormation_formationId",
                table: "tblTitre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblFormation",
                table: "tblFormation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tblFormation");

            migrationBuilder.AddColumn<int>(
                name: "Id_g",
                table: "tblFormation",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblFormation",
                table: "tblFormation",
                column: "Id_g");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTitre_tblFormation_formationId",
                table: "tblTitre",
                column: "formationId",
                principalTable: "tblFormation",
                principalColumn: "Id_g",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTitre_tblFormation_formationId",
                table: "tblTitre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblFormation",
                table: "tblFormation");

            migrationBuilder.DropColumn(
                name: "Id_g",
                table: "tblFormation");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tblFormation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblFormation",
                table: "tblFormation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTitre_tblFormation_formationId",
                table: "tblTitre",
                column: "formationId",
                principalTable: "tblFormation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
