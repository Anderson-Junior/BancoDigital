// <auto-generated />
using System;
using BancoDigital.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BancoDigital.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220914151723_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BancoDigital.Entities.Conta", b =>
                {
                    b.Property<Guid>("ContaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AtualizadaEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CriadaEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NumeroAgencia")
                        .HasColumnType("text");

                    b.Property<string>("NumeroConta")
                        .HasColumnType("text");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("numeric");

                    b.Property<string>("TipoConta")
                        .HasColumnType("text");

                    b.HasKey("ContaId");

                    b.ToTable("Conta");
                });
#pragma warning restore 612, 618
        }
    }
}
