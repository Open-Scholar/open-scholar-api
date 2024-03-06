using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenScholarApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class hotfix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicComments_AspNetUsers_UserId",
                table: "TopicComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Faculties_FacultyId",
                table: "Topics");

            migrationBuilder.RenameIndex(
                name: "IX_UserConnections_UserId",
                table: "UserConnections",
                newName: "IDX_UserConnection_UserId");

            migrationBuilder.CreateIndex(
                name: "IDX_UserConnection_ConnectionId",
                table: "UserConnections",
                column: "ConnectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicComments_AspNetUsers_UserId",
                table: "TopicComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Faculties_FacultyId",
                table: "Topics",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicComments_AspNetUsers_UserId",
                table: "TopicComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Faculties_FacultyId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IDX_UserConnection_ConnectionId",
                table: "UserConnections");

            migrationBuilder.RenameIndex(
                name: "IDX_UserConnection_UserId",
                table: "UserConnections",
                newName: "IX_UserConnections_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicComments_AspNetUsers_UserId",
                table: "TopicComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Faculties_FacultyId",
                table: "Topics",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
