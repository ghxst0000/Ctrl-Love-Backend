using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlLove.Migrations
{
    /// <inheritdoc />
    public partial class InterestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interests",
                table: "UserModel");

            migrationBuilder.CreateTable(
                name: "InterestModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterestModelUserModel",
                columns: table => new
                {
                    InterestsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestModelUserModel", x => new { x.InterestsId, x.UserModelId });
                    table.ForeignKey(
                        name: "FK_InterestModelUserModel_InterestModel_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "InterestModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestModelUserModel_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestModelUserModel_UserModelId",
                table: "InterestModelUserModel",
                column: "UserModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestModelUserModel");

            migrationBuilder.DropTable(
                name: "InterestModel");

            migrationBuilder.AddColumn<int[]>(
                name: "Interests",
                table: "UserModel",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }
    }
}
