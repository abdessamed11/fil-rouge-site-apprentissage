using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LEARNING.Migrations
{
    public partial class fhffdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_tblTitre_TitreId",
                table: "articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblTitre",
                table: "tblTitre");

            migrationBuilder.DropIndex(
                name: "IX_articles_TitreId",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tblTitre");

            migrationBuilder.DropColumn(
                name: "TitreId",
                table: "articles");

            migrationBuilder.AddColumn<int>(
                name: "Id_t",
                table: "tblTitre",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TitreId_t",
                table: "articles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblTitre",
                table: "tblTitre",
                column: "Id_t");

            migrationBuilder.CreateIndex(
                name: "IX_articles_TitreId_t",
                table: "articles",
                column: "TitreId_t");

            migrationBuilder.AddForeignKey(
                name: "FK_articles_tblTitre_TitreId_t",
                table: "articles",
                column: "TitreId_t",
                principalTable: "tblTitre",
                principalColumn: "Id_t",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_tblTitre_TitreId_t",
                table: "articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblTitre",
                table: "tblTitre");

            migrationBuilder.DropIndex(
                name: "IX_articles_TitreId_t",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "Id_t",
                table: "tblTitre");

            migrationBuilder.DropColumn(
                name: "TitreId_t",
                table: "articles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tblTitre",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TitreId",
                table: "articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblTitre",
                table: "tblTitre",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_articles_TitreId",
                table: "articles",
                column: "TitreId");

            migrationBuilder.AddForeignKey(
                name: "FK_articles_tblTitre_TitreId",
                table: "articles",
                column: "TitreId",
                principalTable: "tblTitre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
