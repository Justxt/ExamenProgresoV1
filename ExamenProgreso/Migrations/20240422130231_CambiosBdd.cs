using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenProgreso.Migrations
{
    /// <inheritdoc />
    public partial class CambiosBdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Campus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSemestres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JMora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsMayorDeEdad = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    carreraId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JMora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JMora_Carrera_carreraId",
                        column: x => x.carreraId,
                        principalTable: "Carrera",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JMora_carreraId",
                table: "JMora",
                column: "carreraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JMora");

            migrationBuilder.DropTable(
                name: "Carrera");
        }
    }
}
