using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 26, 14, 36, 20, 836, DateTimeKind.Local).AddTicks(4741), new DateTime(2025, 2, 26, 14, 36, 20, 836, DateTimeKind.Local).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 26, 14, 36, 20, 835, DateTimeKind.Local).AddTicks(193), new DateTime(2025, 2, 26, 14, 36, 20, 835, DateTimeKind.Local).AddTicks(517) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 26, 14, 36, 20, 835, DateTimeKind.Local).AddTicks(1397), new DateTime(2025, 2, 26, 14, 36, 20, 835, DateTimeKind.Local).AddTicks(1398) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 26, 14, 36, 20, 835, DateTimeKind.Local).AddTicks(1388), new DateTime(2025, 2, 26, 14, 36, 20, 835, DateTimeKind.Local).AddTicks(1389) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 22, 43, 9, 560, DateTimeKind.Local).AddTicks(5178), new DateTime(2025, 2, 25, 22, 43, 9, 560, DateTimeKind.Local).AddTicks(5431) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 22, 43, 9, 559, DateTimeKind.Local).AddTicks(3136), new DateTime(2025, 2, 25, 22, 43, 9, 559, DateTimeKind.Local).AddTicks(3546) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 22, 43, 9, 559, DateTimeKind.Local).AddTicks(4415), new DateTime(2025, 2, 25, 22, 43, 9, 559, DateTimeKind.Local).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 22, 43, 9, 559, DateTimeKind.Local).AddTicks(4408), new DateTime(2025, 2, 25, 22, 43, 9, 559, DateTimeKind.Local).AddTicks(4409) });
        }
    }
}
