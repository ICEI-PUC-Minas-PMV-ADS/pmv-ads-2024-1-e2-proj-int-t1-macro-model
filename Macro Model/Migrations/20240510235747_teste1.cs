using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Macro_Model.Migrations
{
    /// <inheritdoc />
    public partial class teste1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nutricional = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Restricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    produtoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Cadastro_Produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Listadefavoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastroCpf = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    ProdutoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listadefavoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listadefavoritos_Cadastro_CadastroCpf",
                        column: x => x.CadastroCpf,
                        principalTable: "Cadastro",
                        principalColumn: "Cpf");
                    table.ForeignKey(
                        name: "FK_Listadefavoritos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_Email",
                table: "Cadastro",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_produtoId",
                table: "Cadastro",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Listadefavoritos_CadastroCpf",
                table: "Listadefavoritos",
                column: "CadastroCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Listadefavoritos_ProdutoId",
                table: "Listadefavoritos",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listadefavoritos");

            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
