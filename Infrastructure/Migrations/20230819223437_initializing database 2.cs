using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initializingdatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_users_Authorid",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "comments",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Authorid",
                table: "blogs",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_Authorid",
                table: "blogs",
                newName: "IX_blogs_AuthorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_users_AuthorId",
                table: "blogs",
                column: "AuthorId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_users_AuthorId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "comments",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "blogs",
                newName: "Authorid");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_AuthorId",
                table: "blogs",
                newName: "IX_blogs_Authorid");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_users_Authorid",
                table: "blogs",
                column: "Authorid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
