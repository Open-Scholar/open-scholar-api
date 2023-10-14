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
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicMaterials_AspNetUsers_UserIdId",
                table: "AcademicMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSellers_AspNetUsers_UserIdId",
                table: "BookSellers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_AspNetUsers_UserIdId",
                table: "BookStores");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_AspNetUsers_UserIdId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_AspNetUsers_UserIdId",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AspNetUsers_UserIdId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_AspNetUsers_UserIdId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_UserIdId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_UserIdId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Professors_UserIdId",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_UserIdId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_BookStores_UserIdId",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookSellers_UserIdId",
                table: "BookSellers");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "BookSellers");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "AcademicMaterials",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicMaterials_UserIdId",
                table: "AcademicMaterials",
                newName: "IX_AcademicMaterials_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Universities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Subjects",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Professors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Faculties",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookStores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookSellers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_UserId",
                table: "Universities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_UserId",
                table: "Subjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_UserId",
                table: "Professors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UserId",
                table: "Faculties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_UserId",
                table: "BookStores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSellers_UserId",
                table: "BookSellers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicMaterials_AspNetUsers_UserId",
                table: "AcademicMaterials",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSellers_AspNetUsers_UserId",
                table: "BookSellers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_AspNetUsers_UserId",
                table: "BookStores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_AspNetUsers_UserId",
                table: "Faculties",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_AspNetUsers_UserId",
                table: "Professors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AspNetUsers_UserId",
                table: "Subjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_AspNetUsers_UserId",
                table: "Universities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicMaterials_AspNetUsers_UserId",
                table: "AcademicMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSellers_AspNetUsers_UserId",
                table: "BookSellers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_AspNetUsers_UserId",
                table: "BookStores");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_AspNetUsers_UserId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_AspNetUsers_UserId",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AspNetUsers_UserId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_AspNetUsers_UserId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_UserId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_UserId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Professors_UserId",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_UserId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_BookStores_UserId",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookSellers_UserId",
                table: "BookSellers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Subjects");

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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AcademicMaterials",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicMaterials_UserId",
                table: "AcademicMaterials",
                newName: "IX_AcademicMaterials_UserIdId");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Subjects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Professors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Faculties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "BookStores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "BookSellers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_UserIdId",
                table: "Universities",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_UserIdId",
                table: "Subjects",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_UserIdId",
                table: "Professors",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UserIdId",
                table: "Faculties",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_UserIdId",
                table: "BookStores",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSellers_UserIdId",
                table: "BookSellers",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicMaterials_AspNetUsers_UserIdId",
                table: "AcademicMaterials",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSellers_AspNetUsers_UserIdId",
                table: "BookSellers",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_AspNetUsers_UserIdId",
                table: "BookStores",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_AspNetUsers_UserIdId",
                table: "Faculties",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_AspNetUsers_UserIdId",
                table: "Professors",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AspNetUsers_UserIdId",
                table: "Subjects",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_AspNetUsers_UserIdId",
                table: "Universities",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
