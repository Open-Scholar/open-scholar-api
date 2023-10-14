using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenScholarApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "AcademicMaterials",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicMaterials_ProfessorId",
                table: "AcademicMaterials",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicMaterials_Professors_ProfessorId",
                table: "AcademicMaterials",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicMaterials_Professors_ProfessorId",
                table: "AcademicMaterials");

            migrationBuilder.DropIndex(
                name: "IX_AcademicMaterials_ProfessorId",
                table: "AcademicMaterials");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "AcademicMaterials");
        }
    }
}
