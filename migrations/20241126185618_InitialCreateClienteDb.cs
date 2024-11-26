using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetopim.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateClienteDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEmpresa = table.Column<string>(type: "TEXT", nullable: false),
                    Cnpj = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CultivosEInsumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CultivoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cultivo = table.Column<string>(type: "TEXT", nullable: false),
                    InsumoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Insumo = table.Column<string>(type: "TEXT", nullable: false),
                    FornecedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fornecedor = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultivosEInsumos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cliente = table.Column<string>(type: "TEXT", nullable: false),
                    Produto = table.Column<string>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    FormaDePagamento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "CultivosEInsumos");

            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
