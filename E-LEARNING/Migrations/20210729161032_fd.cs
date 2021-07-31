using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LEARNING.Migrations
{
    public partial class fd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Student_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Student_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Student_specialization",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "infoTitres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name_form = table.Column<string>(nullable: true),
                    Article_art = table.Column<string>(nullable: true),
                    video_art = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infoTitres", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "infoTitres");

            migrationBuilder.AddColumn<string>(
                name: "Student_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_specialization",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
