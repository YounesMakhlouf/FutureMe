using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FutureMe.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Letters_LetterId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Letters_users_UserId",
                table: "Letters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Letters",
                table: "Letters");

            migrationBuilder.RenameTable(
                name: "Letters",
                newName: "letters");

            migrationBuilder.RenameIndex(
                name: "IX_Letters_UserId",
                table: "letters",
                newName: "IX_letters_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "letters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "letters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "letters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "letters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_letters",
                table: "letters",
                column: "Id");

            migrationBuilder.InsertData(
                table: "letters",
                columns: new[] { "Id", "Content", "Email", "IsPublic", "SendingDate", "Title", "UserId", "WritingDate" },
                values: new object[,]
                {
                    { 1, "Dear future me, I hope you are doing well and have achieved your goals. I am writing this letter to remind you of the things that matter to you and to encourage you to keep going. Remember to be grateful for what you have, to be kind to yourself and others, and to enjoy the present moment. You have come a long way and I am proud of you. Love, your past self.", "user1@example.com", true, new DateTime(2024, 12, 9, 12, 1, 23, 0, DateTimeKind.Local), "A letter to myself", 0, new DateTime(2023, 12, 9, 12, 1, 23, 0, DateTimeKind.Local) },
                    { 2, "Hello future me, I am writing this letter to tell you that you are awesome and that you can do anything you set your mind to. I know you have faced many challenges and overcome many obstacles, but you never gave up. You are strong, resilient, and courageous. I want you to remember that you are not alone, that you have people who love you and support you. I also want you to have fun and enjoy life, because you deserve it. You are amazing and I love you. Sincerely, your past self.", "user2@example.com", false, new DateTime(2025, 12, 9, 12, 1, 23, 0, DateTimeKind.Local), "A letter to myself", 0, new DateTime(2023, 12, 9, 12, 1, 23, 0, DateTimeKind.Local) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_comments_letters_LetterId",
                table: "comments",
                column: "LetterId",
                principalTable: "letters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_letters_users_UserId",
                table: "letters",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_letters_LetterId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_letters_users_UserId",
                table: "letters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_letters",
                table: "letters");

            migrationBuilder.DeleteData(
                table: "letters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "letters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "letters",
                newName: "Letters");

            migrationBuilder.RenameIndex(
                name: "IX_letters_UserId",
                table: "Letters",
                newName: "IX_Letters_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Letters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Letters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Letters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Letters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Letters",
                table: "Letters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Letters_LetterId",
                table: "comments",
                column: "LetterId",
                principalTable: "Letters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_users_UserId",
                table: "Letters",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
