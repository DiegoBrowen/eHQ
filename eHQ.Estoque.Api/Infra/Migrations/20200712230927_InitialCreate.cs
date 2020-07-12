using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eHQ.Estoque.Api.Infra.Migrations
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
                    Ano = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: false)
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
                    Quantidade = table.Column<int>(nullable: false),
                    RevistaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueRevistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueRevistas_Revistas_RevistaId",
                        column: x => x.RevistaId,
                        principalTable: "Revistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueRevistas_RevistaId",
                table: "EstoqueRevistas",
                column: "RevistaId");
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
