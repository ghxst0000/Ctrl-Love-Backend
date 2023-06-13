using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlLove.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chatroom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatroom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "public-user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Interests = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_public-user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "private-user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Likes = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
                    Dislikes = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinimumAge = table.Column<int>(type: "integer", nullable: false),
                    MaximumAge = table.Column<int>(type: "integer", nullable: false),
                    DesiredGenders = table.Column<int[]>(type: "integer[]", nullable: false),
                    ChatRoomModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_private-user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_private-user_chatroom_ChatRoomModelId",
                        column: x => x.ChatRoomModelId,
                        principalTable: "chatroom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_private-user_public-user_Id",
                        column: x => x.Id,
                        principalTable: "public-user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChatRoomModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.ID);
                    table.ForeignKey(
                        name: "FK_message_chatroom_ChatRoomModelId",
                        column: x => x.ChatRoomModelId,
                        principalTable: "chatroom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_message_private-user_SenderId",
                        column: x => x.SenderId,
                        principalTable: "private-user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photos_private-user_userId",
                        column: x => x.userId,
                        principalTable: "private-user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_message_ChatRoomModelId",
                table: "message",
                column: "ChatRoomModelId");

            migrationBuilder.CreateIndex(
                name: "IX_message_SenderId",
                table: "message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_photos_userId",
                table: "photos",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_private-user_ChatRoomModelId",
                table: "private-user",
                column: "ChatRoomModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropTable(
                name: "private-user");

            migrationBuilder.DropTable(
                name: "chatroom");

            migrationBuilder.DropTable(
                name: "public-user");
        }
    }
}
