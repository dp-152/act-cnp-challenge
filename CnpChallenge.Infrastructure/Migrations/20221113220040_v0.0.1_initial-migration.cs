using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CnpChallenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v001initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    DatInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ClienteEndereco",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    DatInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEndereco", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ClienteEndereco_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalSchema: "dbo",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEndereco_IdCliente",
                schema: "dbo",
                table: "ClienteEndereco",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteEndereco",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "dbo");
        }
    }
}
