using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eHQ.Produto.Api.Infra.Migrations
{
    public partial class InitialCreateProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Revistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false),
                    Autor = table.Column<string>(maxLength: 200, nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false),
                    Desenhista = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revistas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revistas");
        }
    }
}
