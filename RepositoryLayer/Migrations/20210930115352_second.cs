using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollaborationId",
                table: "Collaborations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 30, 17, 23, 51, 626, DateTimeKind.Local).AddTicks(9676), new DateTime(2021, 9, 30, 17, 23, 51, 628, DateTimeKind.Local).AddTicks(5316) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollaborationId",
                table: "Collaborations");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 22, 47, 23, 866, DateTimeKind.Local).AddTicks(5112), new DateTime(2021, 9, 29, 22, 47, 23, 866, DateTimeKind.Local).AddTicks(8749) });
        }
    }
}
