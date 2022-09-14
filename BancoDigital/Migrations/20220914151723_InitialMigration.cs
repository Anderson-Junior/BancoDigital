using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDigital.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ContaId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroConta = table.Column<string>(type: "text", nullable: true),
                    NumeroAgencia = table.Column<string>(type: "text", nullable: true),
                    TipoConta = table.Column<string>(type: "text", nullable: true),
                    Saldo = table.Column<decimal>(type: "numeric", nullable: false),
                    CriadaEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AtualizadaEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ContaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
