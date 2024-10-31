using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioChatBot.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime", nullable: false),
                    NomePaciente = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuracaoHoras = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Contato = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmacao = table.Column<bool>(type: "bit", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agenda_Exame_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PreparoExame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    ExameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparoExame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreparoExame_Exame_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ConsultaId",
                table: "Agenda",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ExameId",
                table: "Agenda",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_ConsultaId",
                table: "Exame",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreparoExame_ExameId",
                table: "PreparoExame",
                column: "ExameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "PreparoExame");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "Consulta");
        }
    }
}
