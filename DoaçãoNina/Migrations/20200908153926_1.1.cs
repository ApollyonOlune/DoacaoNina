using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoaçãoNina.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "UltDoa");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "UltDoa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "UltDoa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Valor",
                table: "UltDoa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "UltDoa");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "UltDoa");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "UltDoa");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "UltDoa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
