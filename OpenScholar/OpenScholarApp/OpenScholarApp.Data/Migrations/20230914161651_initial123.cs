using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenScholarApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "WebAdress",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "BookSellers");

            migrationBuilder.AddColumn<string>(
                name: "WebAddress",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Professors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Faculties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Faculties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "BookStores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "BookSellers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BookSellerId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumOfPages",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookSellerId",
                table: "Books",
                column: "BookSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookSellers_BookSellerId",
                table: "Books",
                column: "BookSellerId",
                principalTable: "BookSellers",
                principalColumn: "BookSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "UniversityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookSellers_BookSellerId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookSellerId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "WebAddress",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "BookSellerId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NumOfPages",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Author");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WebAdress",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "BookStores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "BookSellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "BookSellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
