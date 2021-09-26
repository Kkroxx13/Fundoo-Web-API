using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class change2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId1",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserId1",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserId1",
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
                values: new object[] { new DateTime(2021, 9, 26, 12, 17, 47, 837, DateTimeKind.Local).AddTicks(8085), new DateTime(2021, 9, 26, 12, 17, 47, 840, DateTimeKind.Local).AddTicks(910) });

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

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Notes",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 15, 19, 625, DateTimeKind.Local).AddTicks(7192), new DateTime(2021, 9, 26, 12, 15, 19, 627, DateTimeKind.Local).AddTicks(5859) });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId1",
                table: "Notes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId1",
                table: "Notes",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
