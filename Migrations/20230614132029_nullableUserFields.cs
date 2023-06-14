using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlLove.Migrations
{
    /// <inheritdoc />
    public partial class nullableUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestModelUserModel_InterestModel_InterestsId",
                table: "InterestModelUserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestModel",
                table: "InterestModel");

            migrationBuilder.RenameTable(
                name: "InterestModel",
                newName: "Interests");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "UserModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int[]>(
                name: "DesiredGenders",
                table: "UserModel",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(int[]),
                oldType: "integer[]");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "UserModel",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "UserModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interests",
                table: "Interests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestModelUserModel_Interests_InterestsId",
                table: "InterestModelUserModel",
                column: "InterestsId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestModelUserModel_Interests_InterestsId",
                table: "InterestModelUserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interests",
                table: "Interests");

            migrationBuilder.RenameTable(
                name: "Interests",
                newName: "InterestModel");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "UserModel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int[]>(
                name: "DesiredGenders",
                table: "UserModel",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0],
                oldClrType: typeof(int[]),
                oldType: "integer[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "UserModel",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "UserModel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestModel",
                table: "InterestModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestModelUserModel_InterestModel_InterestsId",
                table: "InterestModelUserModel",
                column: "InterestsId",
                principalTable: "InterestModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
