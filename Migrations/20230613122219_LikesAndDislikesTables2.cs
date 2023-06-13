using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlLove.Migrations
{
    /// <inheritdoc />
    public partial class LikesAndDislikesTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModelUserModel");

            migrationBuilder.CreateTable(
                name: "LikeModel",
                columns: table => new
                {
                    UserLikeId = table.Column<Guid>(type: "uuid", nullable: false),
                    LikedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LikedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Liked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeModel", x => x.UserLikeId);
                    table.ForeignKey(
                        name: "FK_LikeModel_UserModel_LikedByUserId",
                        column: x => x.LikedByUserId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LikeModel_UserModel_LikedUserId",
                        column: x => x.LikedUserId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeModel_LikedByUserId",
                table: "LikeModel",
                column: "LikedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeModel_LikedUserId",
                table: "LikeModel",
                column: "LikedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeModel");

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
        }
    }
}
