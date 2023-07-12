using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class initialv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monedas_TEST",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoMoneda = table.Column<string>(type: "varchar(10)", nullable: false),
                    DescripcionMoneda = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas_TEST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios_TEST",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios_TEST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal_TEST",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(250)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(250)", nullable: false),
                    Identificacion = table.Column<string>(type: "varchar(50)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    MonedaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal_TEST", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Sucursal_TEST_Monedas_TEST_MonedaId",
                        column: x => x.MonedaId,
                        principalTable: "Monedas_TEST",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_TEST_MonedaId",
                table: "Sucursal_TEST",
                column: "MonedaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucursal_TEST");

            migrationBuilder.DropTable(
                name: "Usuarios_TEST");

            migrationBuilder.DropTable(
                name: "Monedas_TEST");
        }
    }
}
