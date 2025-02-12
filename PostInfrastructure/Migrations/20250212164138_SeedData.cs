using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Media",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Media",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AccountName", "Content", "CreatedAt", "ParentId", "UpdatedAt" },
                values: new object[] { "4752c4fe-1546-4c01-a46f-e9fcab755389", "tienminh", "Test Du lieu Comment xiu di ban oi", new DateTime(2025, 2, 12, 23, 41, 36, 988, DateTimeKind.Local).AddTicks(3583), "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", new DateTime(2025, 2, 12, 23, 41, 36, 988, DateTimeKind.Local).AddTicks(4375) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "Height", "MediaName", "MediaType", "ParentId", "PostsId", "Url", "Width" },
                values: new object[] { "4758c4fe-1546-4c01-a46f-e9fcab755389", null, "testdulieu", 0, "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", null, "/test", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AccountName", "Content", "CreatedAt", "Privacy", "RepostId", "UpdatedAt" },
                values: new object[] { "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", "thienzn", "Test Du lieu xiu di ban oi", new DateTime(2025, 2, 12, 23, 41, 36, 985, DateTimeKind.Local).AddTicks(2597), 1, null, new DateTime(2025, 2, 12, 23, 41, 36, 985, DateTimeKind.Local).AddTicks(3441) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389");

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: "4758c4fe-1546-4c01-a46f-e9fcab755389");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Media",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Media",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
