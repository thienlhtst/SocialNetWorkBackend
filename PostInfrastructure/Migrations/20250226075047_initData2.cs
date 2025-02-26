using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 26, 14, 50, 46, 582, DateTimeKind.Local).AddTicks(6412), new DateTime(2025, 2, 26, 14, 50, 46, 582, DateTimeKind.Local).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 26, 14, 50, 46, 581, DateTimeKind.Local).AddTicks(3369), new DateTime(2025, 2, 26, 14, 50, 46, 581, DateTimeKind.Local).AddTicks(3708) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 26, 14, 50, 46, 581, DateTimeKind.Local).AddTicks(4603), new DateTime(2025, 2, 26, 14, 50, 46, 581, DateTimeKind.Local).AddTicks(4604) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 26, 14, 50, 46, 581, DateTimeKind.Local).AddTicks(4596), new DateTime(2025, 2, 26, 14, 50, 46, 581, DateTimeKind.Local).AddTicks(4596) });

            migrationBuilder.InsertData(
                table: "TopicUser",
                columns: new[] { "AccountName", "TopicId" },
                values: new object[,]
                {
                    { "thienminh", "a2b3c4d5-e6f7-48a9-b0c1-d2e3f4a5b6c7" },
                    { "thienminh", "d1a5b0c3-4e6f-47a1-b2c4-d5e6f7a8b9c0" },
                    { "thienminh", "e5f6a7b8-c9d0-41e2-b3f4-a5c6d7e8f9b0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TopicUser",
                keyColumns: new[] { "AccountName", "TopicId" },
                keyValues: new object[] { "thienminh", "a2b3c4d5-e6f7-48a9-b0c1-d2e3f4a5b6c7" });

            migrationBuilder.DeleteData(
                table: "TopicUser",
                keyColumns: new[] { "AccountName", "TopicId" },
                keyValues: new object[] { "thienminh", "d1a5b0c3-4e6f-47a1-b2c4-d5e6f7a8b9c0" });

            migrationBuilder.DeleteData(
                table: "TopicUser",
                keyColumns: new[] { "AccountName", "TopicId" },
                keyValues: new object[] { "thienminh", "e5f6a7b8-c9d0-41e2-b3f4-a5c6d7e8f9b0" });

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
    }
}
