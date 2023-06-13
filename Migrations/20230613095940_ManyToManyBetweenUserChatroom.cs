using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlLove.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyBetweenUserChatroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_ChatRoomModels_ChatRoomModelId",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_UserModel_ChatRoomModelId",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "ChatRoomModelId",
                table: "UserModel");

            migrationBuilder.CreateTable(
                name: "ChatRoomModelUserModel",
                columns: table => new
                {
                    ChatRoomModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomModelUserModel", x => new { x.ChatRoomModelId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_ChatRoomModelUserModel_ChatRoomModels_ChatRoomModelId",
                        column: x => x.ChatRoomModelId,
                        principalTable: "ChatRoomModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRoomModelUserModel_UserModel_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomModelUserModel_ParticipantsId",
                table: "ChatRoomModelUserModel",
                column: "ParticipantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRoomModelUserModel");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatRoomModelId",
                table: "UserModel",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_ChatRoomModelId",
                table: "UserModel",
                column: "ChatRoomModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_ChatRoomModels_ChatRoomModelId",
                table: "UserModel",
                column: "ChatRoomModelId",
                principalTable: "ChatRoomModels",
                principalColumn: "Id");
        }
    }
}
