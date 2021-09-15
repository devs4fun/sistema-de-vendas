using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeVendas.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Pagamento_FormaDePagamentoId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_FormaDePagamentoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "FormaDePagamentoId",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "FormaDePagamento",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaDePagamento",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "FormaDePagamentoId",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Cliente",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cartão = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dinheiro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FormaDePagamentoId",
                table: "Vendas",
                column: "FormaDePagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Pagamento_FormaDePagamentoId",
                table: "Vendas",
                column: "FormaDePagamentoId",
                principalTable: "Pagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
