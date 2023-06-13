using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlLove.Migrations
{
    public partial class UpdateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_chatroom_ChatRoomModelId",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_message_private-user_SenderId",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_private-user_userId",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_private-user_chatroom_ChatRoomModelId",
                table: "private-user");

            migrationBuilder.DropForeignKey(
                name: "FK_private-user_public-user_Id",
                table: "private-user");

            migrationBuilder.DropTable(
                name: "public-user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_private-user",
                table: "private-user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chatroom",
                table: "chatroom");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "private-user");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "private-user");

            migrationBuilder.RenameTable(
                name: "private-user",
                newName: "UserModel");

            migrationBuilder.RenameTable(
                name: "chatroom",
                newName: "ChatRoomModels");

            migrationBuilder.RenameIndex(
                name: "IX_private-user_ChatRoomModelId",
                table: "UserModel",
                newName: "IX_UserModel_ChatRoomModelId");

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "UserModel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "UserModel",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "UserModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int[]>(
                name: "Interests",
                table: "UserModel",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserModel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserModel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoomModels",
                table: "ChatRoomModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserModelUserModel",
                columns: table => new
                {
                    DislikesId = table.Column<Guid>(type: "uuid", nullable: false),
                    LikesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModelUserModel", x => new { x.DislikesId, x.LikesId });
                    table.ForeignKey(
                        name: "FK_UserModelUserModel_UserModel_DislikesId",
                        column: x => x.DislikesId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserModelUserModel_UserModel_LikesId",
                        column: x => x.LikesId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserModelUserModel_LikesId",
                table: "UserModelUserModel",
                column: "LikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_message_ChatRoomModels_ChatRoomModelId",
                table: "message",
                column: "ChatRoomModelId",
                principalTable: "ChatRoomModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_message_UserModel_SenderId",
                table: "message",
                column: "SenderId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_UserModel_userId",
                table: "photos",
                column: "userId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_ChatRoomModels_ChatRoomModelId",
                table: "UserModel",
                column: "ChatRoomModelId",
                principalTable: "ChatRoomModels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_ChatRoomModels_ChatRoomModelId",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_message_UserModel_SenderId",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_UserModel_userId",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_ChatRoomModels_ChatRoomModelId",
                table: "UserModel");

            migrationBuilder.DropTable(
                name: "UserModelUserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoomModels",
                table: "ChatRoomModels");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserModel");

            migrationBuilder.RenameTable(
                name: "UserModel",
                newName: "private-user");

            migrationBuilder.RenameTable(
                name: "ChatRoomModels",
                newName: "chatroom");

            migrationBuilder.RenameIndex(
                name: "IX_UserModel_ChatRoomModelId",
                table: "private-user",
                newName: "IX_private-user_ChatRoomModelId");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "Dislikes",
                table: "private-user",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "Likes",
                table: "private-user",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_private-user",
                table: "private-user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chatroom",
                table: "chatroom",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "public-user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Interests = table.Column<int[]>(type: "integer[]", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_public-user", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_message_chatroom_ChatRoomModelId",
                table: "message",
                column: "ChatRoomModelId",
                principalTable: "chatroom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_message_private-user_SenderId",
                table: "message",
                column: "SenderId",
                principalTable: "private-user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_private-user_userId",
                table: "photos",
                column: "userId",
                principalTable: "private-user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private-user_chatroom_ChatRoomModelId",
                table: "private-user",
                column: "ChatRoomModelId",
                principalTable: "chatroom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_private-user_public-user_Id",
                table: "private-user",
                column: "Id",
                principalTable: "public-user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
