using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenScholarApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class update12122 : Migration
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

            migrationBuilder.AddForeignKey(
                name: "FK_TopicCommentLikes_AspNetUsers_UserId",
                table: "TopicCommentLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicLikes_AspNetUsers_UserId",
                table: "TopicLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicCommentLikes_AspNetUsers_UserId",
                table: "TopicCommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicLikes_AspNetUsers_UserId",
                table: "TopicLikes");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicCommentLikes_AspNetUsers_UserId",
                table: "TopicCommentLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicLikes_AspNetUsers_UserId",
                table: "TopicLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
