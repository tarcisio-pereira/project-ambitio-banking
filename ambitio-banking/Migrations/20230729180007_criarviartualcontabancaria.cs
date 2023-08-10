using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ambitio_banking.Migrations
{
    /// <inheritdoc />
    public partial class criarviartualcontabancaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaBancaria_Usuario_UsuarioId",
                table: "ContaBancaria");

            migrationBuilder.DropIndex(
                name: "IX_ContaBancaria_UsuarioId",
                table: "ContaBancaria");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ContaBancaria",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancaria_UsuarioId",
                table: "ContaBancaria",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaBancaria_Usuario_UsuarioId",
                table: "ContaBancaria",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaBancaria_Usuario_UsuarioId",
                table: "ContaBancaria");

            migrationBuilder.DropIndex(
                name: "IX_ContaBancaria_UsuarioId",
                table: "ContaBancaria");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ContaBancaria",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancaria_UsuarioId",
                table: "ContaBancaria",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContaBancaria_Usuario_UsuarioId",
                table: "ContaBancaria",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
