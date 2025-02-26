using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Dataseed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "TopicPost",
                columns: new[] { "PostId", "TopicId" },
                values: new object[,]
                {
                    { "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1", "a2b3c4d5-e6f7-48a9-b0c1-d2e3f4a5b6c7" },
                    { "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", "d1a5b0c3-4e6f-47a1-b2c4-d5e6f7a8b9c0" },
                    { "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", "e5f6a7b8-c9d0-41e2-b3f4-a5c6d7e8f9b0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TopicPost",
                keyColumns: new[] { "PostId", "TopicId" },
                keyValues: new object[] { "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1", "a2b3c4d5-e6f7-48a9-b0c1-d2e3f4a5b6c7" });

            migrationBuilder.DeleteData(
                table: "TopicPost",
                keyColumns: new[] { "PostId", "TopicId" },
                keyValues: new object[] { "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", "d1a5b0c3-4e6f-47a1-b2c4-d5e6f7a8b9c0" });

            migrationBuilder.DeleteData(
                table: "TopicPost",
                keyColumns: new[] { "PostId", "TopicId" },
                keyValues: new object[] { "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", "e5f6a7b8-c9d0-41e2-b3f4-a5c6d7e8f9b0" });

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 22, 42, 15, 195, DateTimeKind.Local).AddTicks(8276), new DateTime(2025, 2, 25, 22, 42, 15, 195, DateTimeKind.Local).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(8189), new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(9250), new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(9251) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(9245), new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(9245) });
        }
    }
}
