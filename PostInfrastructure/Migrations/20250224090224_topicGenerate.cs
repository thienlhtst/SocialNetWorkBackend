using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class topicGenerate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountTopic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPostViews",
                columns: table => new
                {
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostViews", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPostViews_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicPost",
                columns: table => new
                {
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicPost", x => new { x.TopicId, x.PostId });
                    table.ForeignKey(
                        name: "FK_TopicPost_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicPost_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUser", x => new { x.TopicId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TopicUser_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 16, 2, 23, 612, DateTimeKind.Local).AddTicks(5714), new DateTime(2025, 2, 24, 16, 2, 23, 612, DateTimeKind.Local).AddTicks(6053) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 16, 2, 23, 610, DateTimeKind.Local).AddTicks(8120), new DateTime(2025, 2, 24, 16, 2, 23, 610, DateTimeKind.Local).AddTicks(8695) });

            migrationBuilder.CreateIndex(
                name: "IX_TopicPost_PostId",
                table: "TopicPost",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicPost");

            migrationBuilder.DropTable(
                name: "TopicUser");

            migrationBuilder.DropTable(
                name: "UserPostViews");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: "4752c4fe-1546-4c01-a46f-e9fcab755389",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 15, 55, 20, 194, DateTimeKind.Local).AddTicks(1346), new DateTime(2025, 2, 13, 15, 55, 20, 194, DateTimeKind.Local).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 15, 55, 20, 191, DateTimeKind.Local).AddTicks(9697), new DateTime(2025, 2, 13, 15, 55, 20, 192, DateTimeKind.Local).AddTicks(265) });
        }
    }
}
