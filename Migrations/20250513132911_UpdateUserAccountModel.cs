using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBADatalyticsSolutions.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAccountModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistered",
                table: "UserAccounts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserAccounts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserAccounts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "UserAccounts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserAccounts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRegistered",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserAccounts");
        }
    }
}
