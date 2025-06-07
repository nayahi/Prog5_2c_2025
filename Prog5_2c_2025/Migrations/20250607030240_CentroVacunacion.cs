using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prog5_2c_2025.Migrations
{
    /// <inheritdoc />
    public partial class CentroVacunacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "centrosDeVacunacion2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    Creada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modificada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centrosDeVacunacion2", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "centrosDeVacunacion2");
        }
    }
}
