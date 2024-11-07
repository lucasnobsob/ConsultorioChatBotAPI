using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsultorioChatBot.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "CRM", "Especialidade", "Nome" },
                values: new object[] { new Guid("5b073252-4baf-4ed2-bc47-02e82ad921eb"), "101196/SP", "Gastroenterologia", "Alexandre Campos" });

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "Id", "Descricao", "TipoServico" },
                values: new object[,]
                {
                    { new Guid("03c64136-8d2a-4468-9bf5-9be395d5be96"), "§ Endoscopia + Colonoscopia nº60 Preparo", 1 },
                    { new Guid("6ac83258-188f-443a-95b9-a6cc360f57a1"), "Endoscopia Digestiva Alta E Depois digite 60.", 1 },
                    { new Guid("be6d6493-0d50-449e-b51c-a74455198044"), "Virtual Atendimento Via Online.", 0 },
                    { new Guid("dce5e3a4-73c6-45dd-8e83-25bfb9cb6501"), "# Consulta Ou Retorno  - Atendimento Presencial.", 0 },
                    { new Guid("e84c60ad-3e4f-454e-8d98-9e1e98421305"), "Exame Colonoscopia nº 60 Para Preparo.", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: new Guid("5b073252-4baf-4ed2-bc47-02e82ad921eb"));

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: new Guid("03c64136-8d2a-4468-9bf5-9be395d5be96"));

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: new Guid("6ac83258-188f-443a-95b9-a6cc360f57a1"));

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: new Guid("be6d6493-0d50-449e-b51c-a74455198044"));

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: new Guid("dce5e3a4-73c6-45dd-8e83-25bfb9cb6501"));

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: new Guid("e84c60ad-3e4f-454e-8d98-9e1e98421305"));
        }
    }
}
