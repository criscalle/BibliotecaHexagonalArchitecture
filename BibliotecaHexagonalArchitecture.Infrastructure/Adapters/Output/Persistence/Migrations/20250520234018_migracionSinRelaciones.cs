using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaHexagonalArchitecture.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migracionSinRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Historial_Tb_MaterialAcademico_IdMaterial",
                table: "Tb_Historial");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Historial_Tb_Persona_IdPersona",
                table: "Tb_Historial");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_MaterialAcademico_Tb_TipoMaterial_IdTipoMaterial",
                table: "Tb_MaterialAcademico");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Persona_Tb_Rol_IdRol",
                table: "Tb_Persona");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Persona_IdRol",
                table: "Tb_Persona");

            migrationBuilder.DropIndex(
                name: "IX_Tb_MaterialAcademico_IdTipoMaterial",
                table: "Tb_MaterialAcademico");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Historial_IdMaterial",
                table: "Tb_Historial");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Historial_IdPersona",
                table: "Tb_Historial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tb_Persona_IdRol",
                table: "Tb_Persona",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_MaterialAcademico_IdTipoMaterial",
                table: "Tb_MaterialAcademico",
                column: "IdTipoMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Historial_IdMaterial",
                table: "Tb_Historial",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Historial_IdPersona",
                table: "Tb_Historial",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Historial_Tb_MaterialAcademico_IdMaterial",
                table: "Tb_Historial",
                column: "IdMaterial",
                principalTable: "Tb_MaterialAcademico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Historial_Tb_Persona_IdPersona",
                table: "Tb_Historial",
                column: "IdPersona",
                principalTable: "Tb_Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_MaterialAcademico_Tb_TipoMaterial_IdTipoMaterial",
                table: "Tb_MaterialAcademico",
                column: "IdTipoMaterial",
                principalTable: "Tb_TipoMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Persona_Tb_Rol_IdRol",
                table: "Tb_Persona",
                column: "IdRol",
                principalTable: "Tb_Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
