using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class change6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Notes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 34, 15, 459, DateTimeKind.Local).AddTicks(3223), new DateTime(2021, 9, 26, 12, 34, 15, 460, DateTimeKind.Local).AddTicks(9872), 15L });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Notes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 30, 53, 6, DateTimeKind.Local).AddTicks(5109), new DateTime(2021, 9, 26, 12, 30, 53, 8, DateTimeKind.Local).AddTicks(1044), 15 });

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
    }
}
