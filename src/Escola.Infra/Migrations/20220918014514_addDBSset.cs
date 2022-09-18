using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Infra.Migrations
{
    public partial class addDBSset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotasMateria_Boletim_BoletimId",
                table: "NotasMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasMateria_Materia_MateriaId",
                table: "NotasMateria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotasMateria",
                table: "NotasMateria");

            migrationBuilder.RenameTable(
                name: "NotasMateria",
                newName: "Notas Materias");

            migrationBuilder.RenameIndex(
                name: "IX_NotasMateria_MateriaId",
                table: "Notas Materias",
                newName: "IX_Notas Materias_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_NotasMateria_BoletimId",
                table: "Notas Materias",
                newName: "IX_Notas Materias_BoletimId");

            migrationBuilder.AlterColumn<string>(
                name: "Professor",
                table: "Materia",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Materia",
                type: "varchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Semestre",
                table: "Boletim",
                type: "varchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Nota",
                table: "Notas Materias",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas Materias",
                table: "Notas Materias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas Materias_Boletim_BoletimId",
                table: "Notas Materias",
                column: "BoletimId",
                principalTable: "Boletim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas Materias_Materia_MateriaId",
                table: "Notas Materias",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas Materias_Boletim_BoletimId",
                table: "Notas Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas Materias_Materia_MateriaId",
                table: "Notas Materias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas Materias",
                table: "Notas Materias");

            migrationBuilder.RenameTable(
                name: "Notas Materias",
                newName: "NotasMateria");

            migrationBuilder.RenameIndex(
                name: "IX_Notas Materias_MateriaId",
                table: "NotasMateria",
                newName: "IX_NotasMateria_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas Materias_BoletimId",
                table: "NotasMateria",
                newName: "IX_NotasMateria_BoletimId");

            migrationBuilder.AlterColumn<string>(
                name: "Professor",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Semestre",
                table: "Boletim",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Nota",
                table: "NotasMateria",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotasMateria",
                table: "NotasMateria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotasMateria_Boletim_BoletimId",
                table: "NotasMateria",
                column: "BoletimId",
                principalTable: "Boletim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotasMateria_Materia_MateriaId",
                table: "NotasMateria",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
