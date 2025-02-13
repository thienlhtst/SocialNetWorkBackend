using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Datasedd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 15, 55, 20, 194, DateTimeKind.Local).AddTicks(1346), new DateTime(2025, 2, 13, 15, 55, 20, 194, DateTimeKind.Local).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: "4758c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "Height", "Width" },
                values: new object[] { 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 15, 55, 20, 191, DateTimeKind.Local).AddTicks(9697), new DateTime(2025, 2, 13, 15, 55, 20, 192, DateTimeKind.Local).AddTicks(265) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 0, 2, 35, 515, DateTimeKind.Local).AddTicks(7135), new DateTime(2025, 2, 13, 0, 2, 35, 515, DateTimeKind.Local).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: "4758c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "Height", "Width" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 0, 2, 35, 514, DateTimeKind.Local).AddTicks(6913), new DateTime(2025, 2, 13, 0, 2, 35, 514, DateTimeKind.Local).AddTicks(7175) });
        }
    }
}
