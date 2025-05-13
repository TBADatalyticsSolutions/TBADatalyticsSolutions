using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TBADatalyticsSolutions.Migrations
{
    /// <inheritdoc />
    public partial class SeedTrainingCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TrainingCourses",
                columns: new[] { "Id", "CourseTitle", "Description", "DurationWeeks", "Instructor", "Level", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1, "Introduction to Data Analytics", "Learn the basics of analyzing data using modern tools.", 4, "Tahir Bastu Abiodun", "Beginner", 150.00m, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Power BI for Business Intelligence", "Develop interactive dashboards and visual reports with Power BI.", 5, "Adeola Martins", "Intermediate", 250.00m, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Python for Data Science", "Harness the power of Python for data analysis and machine learning.", 6, "Bolu Adeyemi", "Intermediate", 300.00m, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Advanced Machine Learning with Scikit-Learn", "Train and evaluate machine learning models with real-world datasets.", 8, "Kemi Yusuf", "Advanced", 400.00m, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingCourses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingCourses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingCourses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainingCourses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
