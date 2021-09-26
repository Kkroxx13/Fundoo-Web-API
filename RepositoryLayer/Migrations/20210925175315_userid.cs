using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class userid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 25, 23, 23, 15, 158, DateTimeKind.Local).AddTicks(7029), new DateTime(2021, 9, 25, 23, 23, 15, 160, DateTimeKind.Local).AddTicks(4359) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 25, 23, 14, 58, 165, DateTimeKind.Local).AddTicks(7273), new DateTime(2021, 9, 25, 23, 14, 58, 167, DateTimeKind.Local).AddTicks(3564) });
        }
    }
}
