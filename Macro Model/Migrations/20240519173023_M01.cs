using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Macro_Model.Migrations
{
    /// <inheritdoc />
    public partial class M01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Cpf);
                });

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
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nutricional = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Restricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TipoConteudoImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListadefavoritoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Listadefavorito_ListadefavoritoId",
                        column: x => x.ListadefavoritoId,
                        principalTable: "Listadefavorito",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_Email",
                table: "Cadastro",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listadefavorito_Cpf",
                table: "Listadefavorito",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ListadefavoritoId",
                table: "Produtos",
                column: "ListadefavoritoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Listadefavorito");

            migrationBuilder.DropTable(
                name: "Cadastro");
        }
    }
}
