using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace triaCSharp.Migrations
{
    public partial class initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2021, 3, 8, 12, 2, 17, 578, DateTimeKind.Local).AddTicks(1965), new DateTime(2021, 3, 8, 12, 2, 17, 579, DateTimeKind.Local).AddTicks(875) });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Name", "ProdutoId", "company", "createdAt", "mail", "notes", "phone", "updatedAt" },
                values: new object[] { 2, "josé2", 1, "coca", new DateTime(2021, 3, 8, 12, 2, 17, 579, DateTimeKind.Local).AddTicks(3641), "a@asdas.com", "jsahdausi", "12121-2121", new DateTime(2021, 3, 8, 12, 2, 17, 579, DateTimeKind.Local).AddTicks(3646) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2021, 3, 8, 11, 24, 5, 408, DateTimeKind.Local).AddTicks(5607), new DateTime(2021, 3, 8, 11, 24, 5, 409, DateTimeKind.Local).AddTicks(3257) });
        }
    }
}
