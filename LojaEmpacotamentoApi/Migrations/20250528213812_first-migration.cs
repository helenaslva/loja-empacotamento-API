using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaEmpacotamentoApi.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlturaCm = table.Column<float>(type: "real", nullable: false),
                    LarguraCm = table.Column<float>(type: "real", nullable: false),
                    ComprimentoCm = table.Column<float>(type: "real", nullable: false),
                    PesoMaxKg = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlturaCm = table.Column<float>(type: "real", nullable: false),
                    LarguraCm = table.Column<float>(type: "real", nullable: false),
                    ComprimentoCm = table.Column<float>(type: "real", nullable: false),
                    PesoKg = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidoCaixa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaixaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoCaixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoCaixa_Caixa_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoCaixa_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaixaProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoCaixaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaixaProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaixaProduto_PedidoCaixa_PedidoCaixaId",
                        column: x => x.PedidoCaixaId,
                        principalTable: "PedidoCaixa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaixaProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaixaProduto_PedidoCaixaId",
                table: "CaixaProduto",
                column: "PedidoCaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_CaixaProduto_ProdutoId",
                table: "CaixaProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCaixa_CaixaId",
                table: "PedidoCaixa",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCaixa_PedidoId",
                table: "PedidoCaixa",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_PedidoId",
                table: "PedidoProduto",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_ProdutoId",
                table: "PedidoProduto",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaixaProduto");

            migrationBuilder.DropTable(
                name: "PedidoProduto");

            migrationBuilder.DropTable(
                name: "PedidoCaixa");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Caixa");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
