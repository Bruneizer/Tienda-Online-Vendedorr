using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class AddUrlToPublicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Producto_productoId",
                table: "Publicacion");

            migrationBuilder.RenameColumn(
                name: "productoId",
                table: "Publicacion",
                newName: "ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacion_productoId",
                table: "Publicacion",
                newName: "IX_Publicacion_ProductoId");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Publicacion",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "VendedorId",
                table: "Publicacion",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Producto",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_VendedorId",
                table: "Publicacion",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Producto_ProductoId",
                table: "Publicacion",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Vendedor_VendedorId",
                table: "Publicacion",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Producto_ProductoId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Vendedor_VendedorId",
                table: "Publicacion");

            migrationBuilder.DropIndex(
                name: "IX_Publicacion_VendedorId",
                table: "Publicacion");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Publicacion");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "Publicacion");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Publicacion",
                newName: "productoId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacion_ProductoId",
                table: "Publicacion",
                newName: "IX_Publicacion_productoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Producto_productoId",
                table: "Publicacion",
                column: "productoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
