using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Macro_Model.Migrations
{
    /// <inheritdoc />
    public partial class M01Azure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

          
            migrationBuilder.CreateTable(
                name: "Listadefavorito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listadefavorito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listadefavorito_Cadastro_Cpf",
                        column: x => x.Cpf,
                        principalTable: "Cadastro",
                        principalColumn: "Cpf");
                });

            migrationBuilder.CreateTable(
                name: "RelacaoProdutoListas",
                columns: table => new
                {
                    ListadefavoritoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacaoProdutoListas", x => new { x.ListadefavoritoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_RelacaoProdutoListas_Listadefavorito_ListadefavoritoId",
                        column: x => x.ListadefavoritoId,
                        principalTable: "Listadefavorito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelacaoProdutoListas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelacaoProdutoListas_Produtos_ProdutoId1",
                        column: x => x.ProdutoId1,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

    

    
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacaoProdutoListas");

            migrationBuilder.DropTable(
                name: "Listadefavorito");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Cadastro");
        }
    }
}
