using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Macro_Model.Migrations
{
    /// <inheritdoc />
    public partial class M03CatCaloria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Caloria",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caloria",
                table: "Produtos");
        }
    }
}
