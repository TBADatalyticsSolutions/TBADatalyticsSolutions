using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBADatalyticsSolutions.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Analytics",
                table: "Analytics");

            migrationBuilder.RenameTable(
                name: "Analytics",
                newName: "AnalyticsData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnalyticsData",
                table: "AnalyticsData",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnalyticsData",
                table: "AnalyticsData");

            migrationBuilder.RenameTable(
                name: "AnalyticsData",
                newName: "Analytics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Analytics",
                table: "Analytics",
                column: "Id");
        }
    }
}
