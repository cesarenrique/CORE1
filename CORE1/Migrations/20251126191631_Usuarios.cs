using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CORE1.Migrations
{
    /// <inheritdoc />
    public partial class Usuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tallercore2");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "tallercore2",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaalta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    apellidos = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    clave = table.Column<string>(type: "varchar(50)", nullable: false),
                    rol = table.Column<string>(type: "varchar(20)", nullable: false),
                    activo = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "tallercore2");
        }
    }
}
