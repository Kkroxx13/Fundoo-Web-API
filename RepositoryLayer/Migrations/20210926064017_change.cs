using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new DateTime(2021, 9, 26, 12, 10, 16, 484, DateTimeKind.Local).AddTicks(3425), new DateTime(2021, 9, 26, 12, 10, 16, 486, DateTimeKind.Local).AddTicks(381) });

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
                values: new object[] { new DateTime(2021, 9, 25, 23, 30, 31, 376, DateTimeKind.Local).AddTicks(4365), new DateTime(2021, 9, 25, 23, 30, 31, 378, DateTimeKind.Local).AddTicks(2709) });
        }
    }
}
