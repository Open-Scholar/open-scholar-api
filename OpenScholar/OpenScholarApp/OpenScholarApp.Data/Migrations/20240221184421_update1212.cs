using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenScholarApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class update1212 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicCommentLikes_AspNetUsers_UserId",
                table: "TopicCommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicLikes_AspNetUsers_UserId",
                table: "TopicLikes");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Topics",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TopicComments",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ApplicationUserId",
                table: "Topics",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicComments_ApplicationUserId",
                table: "TopicComments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicCommentLikes_AspNetUsers_UserId",
                table: "TopicCommentLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicComments_AspNetUsers_ApplicationUserId",
                table: "TopicComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicLikes_AspNetUsers_UserId",
                table: "TopicLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_ApplicationUserId",
                table: "Topics",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicCommentLikes_AspNetUsers_UserId",
                table: "TopicCommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicComments_AspNetUsers_ApplicationUserId",
                table: "TopicComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicLikes_AspNetUsers_UserId",
                table: "TopicLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_ApplicationUserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_ApplicationUserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_TopicComments_ApplicationUserId",
                table: "TopicComments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TopicComments");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicCommentLikes_AspNetUsers_UserId",
                table: "TopicCommentLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicLikes_AspNetUsers_UserId",
                table: "TopicLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
