using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class nuevastablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "Lessons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    ConversationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.ConversationId);
                });

            migrationBuilder.CreateTable(
                name: "Dialogue",
                columns: table => new
                {
                    DialogueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 1000, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ConversationId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogue", x => x.DialogueId);
                    table.ForeignKey(
                        name: "FK_Dialogue_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dialogue_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 1,
                column: "Description",
                value: "This card has supporting text below as a natural lead-in to additional content.");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ConversationId",
                table: "Lessons",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogue_CharacterId",
                table: "Dialogue",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogue_ConversationId",
                table: "Dialogue",
                column: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Conversation_ConversationId",
                table: "Lessons",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "ConversationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Conversation_ConversationId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Dialogue");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ConversationId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Lessons");

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "Description", "LevelId", "Name" },
                values: new object[] { 3, "", null, "Divorce" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "Description", "LevelId", "Name" },
                values: new object[] { 2, "", null, "Job Interview" });
        }
    }
}
