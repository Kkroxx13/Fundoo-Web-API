using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class change8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserId",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "NotesId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 57, 54, 765, DateTimeKind.Local).AddTicks(4233), new DateTime(2021, 9, 26, 12, 57, 54, 766, DateTimeKind.Local).AddTicks(8602) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_NotesId",
                table: "Users",
                column: "NotesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Notes_NotesId",
                table: "Users",
                column: "NotesId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Notes_NotesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NotesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NotesId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 56, 12, 333, DateTimeKind.Local).AddTicks(3733), new DateTime(2021, 9, 26, 12, 56, 12, 334, DateTimeKind.Local).AddTicks(7254) });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
