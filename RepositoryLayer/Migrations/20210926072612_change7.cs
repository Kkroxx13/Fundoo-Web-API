using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class change7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 56, 12, 333, DateTimeKind.Local).AddTicks(3733), new DateTime(2021, 9, 26, 12, 56, 12, 334, DateTimeKind.Local).AddTicks(7254) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 34, 15, 459, DateTimeKind.Local).AddTicks(3223), new DateTime(2021, 9, 26, 12, 34, 15, 460, DateTimeKind.Local).AddTicks(9872) });
        }
    }
}
