using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDigital.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Titular_TitularId",
                table: "Conta");

            migrationBuilder.DropTable(
                name: "Titular");

            migrationBuilder.DropIndex(
                name: "IX_Conta_TitularId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "TitularId",
                table: "Conta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TitularId",
                table: "Conta",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Titular",
                columns: table => new
                {
                    TitularId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titular", x => x.TitularId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_TitularId",
                table: "Conta",
                column: "TitularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Titular_TitularId",
                table: "Conta",
                column: "TitularId",
                principalTable: "Titular",
                principalColumn: "TitularId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
