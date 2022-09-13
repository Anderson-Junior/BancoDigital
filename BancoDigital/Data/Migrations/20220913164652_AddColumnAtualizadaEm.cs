using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDigital.Data.Migrations
{
    public partial class AddColumnAtualizadaEm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadaEm",
                table: "Conta",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtualizadaEm",
                table: "Conta");
        }
    }
}
