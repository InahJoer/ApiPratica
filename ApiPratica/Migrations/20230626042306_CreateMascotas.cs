using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiPratica.Migrations
{
    /// <inheritdoc />
    public partial class CreateMascotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    RazaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RazaColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.RazaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    MascotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MascotaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RazaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.MascotaId);
                    table.ForeignKey(
                        name: "FK_Mascotas_Raza_RazaId",
                        column: x => x.RazaId,
                        principalTable: "Raza",
                        principalColumn: "RazaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Raza",
                columns: new[] { "RazaId", "RazaColor", "RazaName" },
                values: new object[,]
                {
                    { 1, "Negrote", "Chihuahua" },
                    { 2, "Verde", "Pitbull" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contraseña", "NombreUsuario", "Rol" },
                values: new object[,]
                {
                    { 1, "holaquepasa", "Chejudos", "Administrador" },
                    { 2, "megustanmenores", "Mrpimiento", "Vendedor" }
                });

            migrationBuilder.InsertData(
                table: "Mascotas",
                columns: new[] { "MascotaId", "Fecha", "MascotaDescription", "MascotaName", "RazaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pequeño", "Juan", 1 },
                    { 2, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorda", "Oswaldo", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_RazaId",
                table: "Mascotas",
                column: "RazaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Raza");
        }
    }
}
