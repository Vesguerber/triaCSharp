using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace triaCSharp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Desenvolvimento de App" },
                    { 2, "Desenvolvimento Web" },
                    { 3, "Integração com SAP" },
                    { 4, "Integração com Mastersaf" },
                    { 5, "Suporte Nível Especialista" },
                    { 6, "Solução Tributária" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Name", "ProdutoId", "company", "createdAt", "mail", "notes", "phone", "updatedAt" },
                values: new object[] { 1, "josé", 1, "coca", new DateTime(2021, 3, 8, 11, 24, 5, 408, DateTimeKind.Local).AddTicks(5607), "a@asdas.com", "jsahdausi", "12121-2121", new DateTime(2021, 3, 8, 11, 24, 5, 409, DateTimeKind.Local).AddTicks(3257) });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ProdutoId",
                table: "Clientes",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
