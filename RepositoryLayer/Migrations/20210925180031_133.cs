using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class _133 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 25, 23, 30, 31, 376, DateTimeKind.Local).AddTicks(4365), new DateTime(2021, 9, 25, 23, 30, 31, 378, DateTimeKind.Local).AddTicks(2709) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 25, 23, 23, 15, 158, DateTimeKind.Local).AddTicks(7029), new DateTime(2021, 9, 25, 23, 23, 15, 160, DateTimeKind.Local).AddTicks(4359) });
        }
    }
}
