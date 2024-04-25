using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Macro_Model.Migrations
{
    /// <inheritdoc />
    public partial class M02autentiocaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Cadastro_CadatroCpf",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CadatroCpf",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CadatroCpf",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "produtoId",
                table: "Cadastro",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_produtoId",
                table: "Cadastro",
                column: "produtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cadastro_Produtos_produtoId",
                table: "Cadastro",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cadastro_Produtos_produtoId",
                table: "Cadastro");

            migrationBuilder.DropIndex(
                name: "IX_Cadastro_produtoId",
                table: "Cadastro");

            migrationBuilder.DropColumn(
                name: "produtoId",
                table: "Cadastro");

            migrationBuilder.AddColumn<string>(
                name: "CadatroCpf",
                table: "Produtos",
                type: "nvarchar(11)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Cpf);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CadatroCpf",
                table: "Produtos",
                column: "CadatroCpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Cadastro_CadatroCpf",
                table: "Produtos",
                column: "CadatroCpf",
                principalTable: "Cadastro",
                principalColumn: "Cpf");
        }
    }
}
