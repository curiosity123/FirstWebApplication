﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyWebApp.EF;
using MyWebApp.Models;
using System;

namespace MyWebApp.Migrations
{
    [DbContext(typeof(PostsContext))]
    partial class PostsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebApp.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("NickName");

                    b.Property<Guid?>("PostId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("MyWebApp.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<DateTime>("Created");

                    b.Property<string>("HtmlContent");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MyWebApp.Models.Comment", b =>
                {
                    b.HasOne("MyWebApp.Models.Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });
#pragma warning restore 612, 618
        }
    }
}