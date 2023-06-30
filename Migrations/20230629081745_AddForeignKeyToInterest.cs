﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlLove.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToInterest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Interests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Interests");
        }
    }
}
