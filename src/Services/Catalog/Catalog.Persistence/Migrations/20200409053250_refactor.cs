using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogue_Conversation_ConversationId",
                table: "Dialogue");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Conversation_ConversationId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ConversationId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Dialogue_ConversationId",
                table: "Dialogue");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Dialogue");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Lessons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Dialogue",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dialogue_LessonId",
                table: "Dialogue",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogue_Lessons_LessonId",
                table: "Dialogue",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogue_Lessons_LessonId",
                table: "Dialogue");

            migrationBuilder.DropIndex(
                name: "IX_Dialogue_LessonId",
                table: "Dialogue");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Dialogue");

            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "Dialogue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.ConversationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ConversationId",
                table: "Lessons",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogue_ConversationId",
                table: "Dialogue",
                column: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogue_Conversation_ConversationId",
                table: "Dialogue",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "ConversationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Conversation_ConversationId",
                table: "Lessons",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "ConversationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
