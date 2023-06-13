using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlLove.Migrations
{
    /// <inheritdoc />
    public partial class LikesAndDislikesTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel");

            migrationBuilder.DropIndex(
                name: "IX_LikeModel_LikedByUserId",
                table: "LikeModel");

            migrationBuilder.DropColumn(
                name: "UserLikeId",
                table: "LikeModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "LikedUserId",
                table: "LikeModel",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "LikedByUserId",
                table: "LikeModel",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel",
                columns: new[] { "LikedByUserId", "LikedUserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "LikedUserId",
                table: "LikeModel",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "LikedByUserId",
                table: "LikeModel",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<Guid>(
                name: "UserLikeId",
                table: "LikeModel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel",
                column: "UserLikeId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeModel_LikedByUserId",
                table: "LikeModel",
                column: "LikedByUserId");
        }
    }
}
