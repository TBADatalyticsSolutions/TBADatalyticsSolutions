using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TBADatalyticsSolutions.Migrations
{
    /// <inheritdoc />
    public partial class SeedServicesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "IconClass", "Title" },
                values: new object[,]
                {
                    { 1, "Professional research support using qualitative and quantitative data techniques.", "icons/research.png", "Research Analysis" },
                    { 2, "Transform your business data into actionable insights and performance metrics.", "icons/bi.png", "Business Intelligence" },
                    { 3, "Expert analytics advisory services for smarter decision-making.", "icons/consulting.png", "Data Analytics Consulting" },
                    { 4, "Hands-on training in Excel, SPSS, R, Python, and MySQL for aspiring analysts.", "icons/training.png", "Data Analytics Training" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
