using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Dataseed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Privacy = table.Column<int>(type: "int", nullable: false),
                    RepostId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    AccountName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostIdOrCommentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => new { x.AccountName, x.PostIdOrCommentId });
                });

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
                    AccountName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostViews", x => new { x.PostId, x.AccountName });
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
                    AccountName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUser", x => new { x.TopicId, x.AccountName });
                    table.ForeignKey(
                        name: "FK_TopicUser_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AccountName", "Content", "CreatedAt", "ParentId", "UpdatedAt" },
                values: new object[] { "4752c4fe-1546-4c01-a46f-e9fcab755389", "tienminh", "Test Du lieu Comment xiu di ban oi", new DateTime(2025, 2, 25, 22, 42, 15, 195, DateTimeKind.Local).AddTicks(8276), "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", new DateTime(2025, 2, 25, 22, 42, 15, 195, DateTimeKind.Local).AddTicks(8484) });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "Height", "MediaName", "MediaType", "ParentId", "Url", "Width" },
                values: new object[] { "4758c4fe-1546-4c01-a46f-e9fcab755389", 0.0, "testdulieu", 0, "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", "/test", 0.0 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AccountName", "Content", "CreatedAt", "Privacy", "RepostId", "UpdatedAt" },
                values: new object[,]
                {
                    { "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", "thienzn", "AI đang thay đổi thế giới như thế nào?", new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(8189), 1, null, new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(8432) },
                    { "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", "minhthanh", "Bản hit mới nhất của ca sĩ X đang làm mưa làm gió", new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(9250), 1, null, new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(9251) },
                    { "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1", "tienminh", "Chung kết Champions League sắp diễn ra!", new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(9245), 1, null, new DateTime(2025, 2, 25, 22, 42, 15, 194, DateTimeKind.Local).AddTicks(9245) }
                });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "CountTopic", "Name" },
                values: new object[,]
                {
                    { "a2b3c4d5-e6f7-48a9-b0c1-d2e3f4a5b6c7", 0, "Thể thao" },
                    { "d1a5b0c3-4e6f-47a1-b2c4-d5e6f7a8b9c0", 0, "Công nghệ" },
                    { "e5f6a7b8-c9d0-41e2-b3f4-a5c6d7e8f9b0", 0, "Âm nhạc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicPost_PostId",
                table: "TopicPost",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Reaction");

            migrationBuilder.DropTable(
                name: "TopicPost");

            migrationBuilder.DropTable(
                name: "TopicUser");

            migrationBuilder.DropTable(
                name: "UserPostViews");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
