using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class newModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "AddReminder", "Color", "CreatedDate", "Image", "IsArchive", "IsNote", "IsPin", "IsTrash", "Message", "ModifiedDate", "Title", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", new DateTime(2021, 9, 25, 23, 14, 58, 165, DateTimeKind.Local).AddTicks(7273), "abc.jpg", false, true, false, false, "Hello, this is my new note", new DateTime(2021, 9, 25, 23, 14, 58, 167, DateTimeKind.Local).AddTicks(3564), "New Note", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
