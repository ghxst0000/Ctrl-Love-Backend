﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CtrlLove.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CtrlLove.Migrations
{
    [DbContext(typeof(CtrlLoveContext))]
    [Migration("20230612125300_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CtrlLove.Models.ChatRoomModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("chatroom");
                });

            modelBuilder.Entity("CtrlLove.Models.MessageModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ChatRoomModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("ChatRoomModelId");

                    b.HasIndex("SenderId");

                    b.ToTable("message");
                });

            modelBuilder.Entity("CtrlLove.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("photos");
                });

            modelBuilder.Entity("CtrlLove.Models.PublicUserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<int[]>("Interests")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("public-user");
                });

            modelBuilder.Entity("CtrlLove.Models.UserModel", b =>
                {
                    b.HasBaseType("CtrlLove.Models.PublicUserModel");

                    b.Property<Guid?>("ChatRoomModelId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int[]>("DesiredGenders")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<List<Guid>>("Dislikes")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<Guid>>("Likes")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<int>("MaximumAge")
                        .HasColumnType("integer");

                    b.Property<int>("MinimumAge")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("ChatRoomModelId");

                    b.ToTable("private-user");
                });

            modelBuilder.Entity("CtrlLove.Models.MessageModel", b =>
                {
                    b.HasOne("CtrlLove.Models.ChatRoomModel", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatRoomModelId");

                    b.HasOne("CtrlLove.Models.UserModel", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("CtrlLove.Models.Photo", b =>
                {
                    b.HasOne("CtrlLove.Models.UserModel", "user")
                        .WithMany("Photos")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("CtrlLove.Models.UserModel", b =>
                {
                    b.HasOne("CtrlLove.Models.ChatRoomModel", null)
                        .WithMany("Participants")
                        .HasForeignKey("ChatRoomModelId");

                    b.HasOne("CtrlLove.Models.PublicUserModel", null)
                        .WithOne()
                        .HasForeignKey("CtrlLove.Models.UserModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CtrlLove.Models.ChatRoomModel", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("CtrlLove.Models.UserModel", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
