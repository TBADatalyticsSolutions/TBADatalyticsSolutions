using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBADatalyticsSolutions.Migrations
{
    /// <inheritdoc />
    public partial class RenamePasswordToPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserAccounts",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "UserAccounts",
                newName: "ConfirmationToken");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPasswordHash",
                table: "UserAccounts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "UserAccounts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPasswordHash",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "UserAccounts");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "UserAccounts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "ConfirmationToken",
                table: "UserAccounts",
                newName: "FullName");
        }
    }
}
