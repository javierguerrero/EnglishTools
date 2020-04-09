using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class dataseedlessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "Description", "LevelId", "Name" },
                values: new object[] { 1, "", null, "Kramer's take about life" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "Description", "LevelId", "Name" },
                values: new object[] { 2, "", null, "Job Interview" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "Description", "LevelId", "Name" },
                values: new object[] { 3, "", null, "Divorce" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 3);
        }
    }
}
