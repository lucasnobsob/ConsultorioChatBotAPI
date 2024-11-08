using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsultorioChatBot.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", nullable: false),
                    Especialidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    CRM = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    PreparoExame = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoServico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Contato = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmacao = table.Column<bool>(type: "bit", nullable: false),
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agenda_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicoServico",
                columns: table => new
                {
                    MedicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoServico", x => new { x.MedicosId, x.ServicosId });
                    table.ForeignKey(
                        name: "FK_MedicoServico_Medicos_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicoServico_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "CRM", "Especialidade", "Nome" },
                values: new object[] { new Guid("cc2d0a62-a230-42f7-8c06-4c4917f933d8"), "101196/SP", "Gastroenterologia", "Alexandre Campos" });

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "Id", "Descricao", "PreparoExame", "TipoServico" },
                values: new object[,]
                {
                    { new Guid("6dc5206b-f685-4879-88c5-850eefb35dd5"), "Endoscopia Digestiva Alta E Depois digite 60.", null, 1 },
                    { new Guid("9ed2df1e-ae89-4c03-a554-fd1c66297455"), "# Consulta Ou Retorno  - Atendimento Presencial.", null, 0 },
                    { new Guid("c650a821-3ee1-4b7f-b90c-5a5b988e562f"), "§ Endoscopia + Colonoscopia nº60 Preparo", null, 1 },
                    { new Guid("d1b32085-6104-4abd-87ca-c4600cec5ca2"), "Virtual Atendimento Via Online.", null, 0 },
                    { new Guid("f61a1f4d-f2ff-4f38-b318-89768a29c21c"), "Exame Colonoscopia nº 60 Para Preparo.", null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_MedicoId",
                table: "Agenda",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ServicoId",
                table: "Agenda",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoServico_ServicosId",
                table: "MedicoServico",
                column: "ServicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "MedicoServico");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Servicos");
        }
    }
}
