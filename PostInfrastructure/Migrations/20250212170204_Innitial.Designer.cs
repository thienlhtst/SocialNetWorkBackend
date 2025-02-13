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
    [Migration("20250212170204_Innitial")]
    partial class Innitial
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

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Media", (string)null);
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
#pragma warning restore 612, 618
        }
    }
}
