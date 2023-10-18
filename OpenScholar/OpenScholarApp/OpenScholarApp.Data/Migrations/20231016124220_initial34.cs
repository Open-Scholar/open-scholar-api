using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenScholarApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniversityId",
                table: "Universities",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Universities",
                newName: "UniversityId");
        }
    }
}
