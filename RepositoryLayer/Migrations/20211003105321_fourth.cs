using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 10, 3, 16, 23, 20, 779, DateTimeKind.Local).AddTicks(477), new DateTime(2021, 10, 3, 16, 23, 20, 780, DateTimeKind.Local).AddTicks(7294) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 10, 3, 15, 39, 20, 729, DateTimeKind.Local).AddTicks(5031), new DateTime(2021, 10, 3, 15, 39, 20, 730, DateTimeKind.Local).AddTicks(7246) });
        }
    }
}
