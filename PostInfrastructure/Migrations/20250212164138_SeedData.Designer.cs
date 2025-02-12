﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostInfrastructure;

#nullable disable

namespace PostInfrastructure.Migrations
{
    [DbContext(typeof(PostDbContext))]
    [Migration("20250212164138_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PostCore.Entities.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Comment", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4752c4fe-1546-4c01-a46f-e9fcab755389",
                            AccountName = "tienminh",
                            Content = "Test Du lieu Comment xiu di ban oi",
                            CreatedAt = new DateTime(2025, 2, 12, 23, 41, 36, 988, DateTimeKind.Local).AddTicks(3583),
                            ParentId = "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                            UpdatedAt = new DateTime(2025, 2, 12, 23, 41, 36, 988, DateTimeKind.Local).AddTicks(4375)
                        });
                });

            modelBuilder.Entity("PostCore.Entities.Media", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<string>("MediaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaType")
                        .HasColumnType("int");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PostsId");

                    b.ToTable("Media", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4758c4fe-1546-4c01-a46f-e9fcab755389",
                            MediaName = "testdulieu",
                            MediaType = 0,
                            ParentId = "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                            Url = "/test"
                        });
                });

            modelBuilder.Entity("PostCore.Entities.Posts", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Privacy")
                        .HasColumnType("int");

                    b.Property<string>("RepostId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Posts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                            AccountName = "thienzn",
                            Content = "Test Du lieu xiu di ban oi",
                            CreatedAt = new DateTime(2025, 2, 12, 23, 41, 36, 985, DateTimeKind.Local).AddTicks(2597),
                            Privacy = 1,
                            UpdatedAt = new DateTime(2025, 2, 12, 23, 41, 36, 985, DateTimeKind.Local).AddTicks(3441)
                        });
                });

            modelBuilder.Entity("PostCore.Entities.Reaction", b =>
                {
                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostIdOrCommentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AccountName", "PostIdOrCommentId");

                    b.ToTable("Reaction", (string)null);
                });

            modelBuilder.Entity("PostCore.Entities.Media", b =>
                {
                    b.HasOne("PostCore.Entities.Posts", null)
                        .WithMany("Medias")
                        .HasForeignKey("PostsId");
                });

            modelBuilder.Entity("PostCore.Entities.Posts", b =>
                {
                    b.Navigation("Medias");
                });
#pragma warning restore 612, 618
        }
    }
}
