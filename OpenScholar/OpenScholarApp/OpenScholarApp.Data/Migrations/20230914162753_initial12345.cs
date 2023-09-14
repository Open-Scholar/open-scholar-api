using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenScholarApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial12345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookSellers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Universities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Professors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Faculties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BookStores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BookSellers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_ApplicationUserId",
                table: "Universities",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_ApplicationUserId",
                table: "Professors",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_ApplicationUserId",
                table: "Faculties",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_ApplicationUserId",
                table: "BookStores",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSellers_ApplicationUserId",
                table: "BookSellers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSellers_AspNetUsers_ApplicationUserId",
                table: "BookSellers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_AspNetUsers_ApplicationUserId",
                table: "BookStores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_AspNetUsers_ApplicationUserId",
                table: "Faculties",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_AspNetUsers_ApplicationUserId",
                table: "Professors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_AspNetUsers_ApplicationUserId",
                table: "Universities",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSellers_AspNetUsers_ApplicationUserId",
                table: "BookSellers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_AspNetUsers_ApplicationUserId",
                table: "BookStores");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_AspNetUsers_ApplicationUserId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_AspNetUsers_ApplicationUserId",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_AspNetUsers_ApplicationUserId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_ApplicationUserId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Professors_ApplicationUserId",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_ApplicationUserId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_BookStores_ApplicationUserId",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookSellers_ApplicationUserId",
                table: "BookSellers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BookSellers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Universities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Professors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookStores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookSellers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
