using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class modificandoDatos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                column: "Nombre",
                value: "Actividades personalesEdit");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                column: "Nombre",
                value: "Actividades pendientesEdit");

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                columns: new[] { "FechaCreacion", "Titulo" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 38, 15, 816, DateTimeKind.Local).AddTicks(2511), "Pago de servicios publicosEdit" });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                columns: new[] { "FechaCreacion", "Titulo" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 38, 15, 816, DateTimeKind.Local).AddTicks(2526), "Terminar de ver pelicula en netflixEdit" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                column: "Nombre",
                value: "Actividades personales");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                column: "Nombre",
                value: "Actividades pendientes");

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                columns: new[] { "FechaCreacion", "Titulo" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 36, 51, 534, DateTimeKind.Local).AddTicks(8197), "Pago de servicios publicos" });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                columns: new[] { "FechaCreacion", "Titulo" },
                values: new object[] { new DateTime(2022, 11, 22, 11, 36, 51, 534, DateTimeKind.Local).AddTicks(8211), "Terminar de ver pelicula en netflix" });
        }
    }
}
