using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class commentsectionadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_users_Authorid",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogImage_Blog_blogId",
                table: "BlogImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogImage",
                table: "BlogImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "users");

            migrationBuilder.RenameTable(
                name: "BlogImage",
                newName: "blog_images");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "blogs");

            migrationBuilder.RenameIndex(
                name: "IX_BlogImage_blogId",
                table: "blog_images",
                newName: "IX_blog_images_blogId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_Authorid",
                table: "blogs",
                newName: "IX_blogs_Authorid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog_images",
                table: "blog_images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogs",
                table: "blogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    blogId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_blogs_blogId",
                        column: x => x.blogId,
                        principalTable: "blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_blogId",
                table: "comments",
                column: "blogId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_userId",
                table: "comments",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_images_blogs_blogId",
                table: "blog_images",
                column: "blogId",
                principalTable: "blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_users_Authorid",
                table: "blogs",
                column: "Authorid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_images_blogs_blogId",
                table: "blog_images");

            migrationBuilder.DropForeignKey(
                name: "FK_blogs_users_Authorid",
                table: "blogs");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogs",
                table: "blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog_images",
                table: "blog_images");

            migrationBuilder.RenameTable(
                name: "blogs",
                newName: "Blog");

            migrationBuilder.RenameTable(
                name: "blog_images",
                newName: "BlogImage");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_Authorid",
                table: "Blog",
                newName: "IX_Blog_Authorid");

            migrationBuilder.RenameIndex(
                name: "IX_blog_images_blogId",
                table: "BlogImage",
                newName: "IX_BlogImage_blogId");

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "users",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogImage",
                table: "BlogImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_users_Authorid",
                table: "Blog",
                column: "Authorid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImage_Blog_blogId",
                table: "BlogImage",
                column: "blogId",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
