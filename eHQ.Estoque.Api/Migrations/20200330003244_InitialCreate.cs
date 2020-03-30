using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eHQ.Estoque.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Revistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false),
                    Autor = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueRevistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdRevista = table.Column<Guid>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueRevistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueRevistas_Revistas_IdRevista",
                        column: x => x.IdRevista,
                        principalTable: "Revistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueRevistas_IdRevista",
                table: "EstoqueRevistas",
                column: "IdRevista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstoqueRevistas");

            migrationBuilder.DropTable(
                name: "Revistas");
        }
    }
}
