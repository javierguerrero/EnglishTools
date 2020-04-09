using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class refactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogue_Character_CharacterId",
                table: "Dialogue");

            migrationBuilder.DropForeignKey(
                name: "FK_Dialogue_Lessons_LessonId",
                table: "Dialogue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dialogue",
                table: "Dialogue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.RenameTable(
                name: "Dialogue",
                newName: "Dialogues");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_Dialogue_LessonId",
                table: "Dialogues",
                newName: "IX_Dialogues_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Dialogue_CharacterId",
                table: "Dialogues",
                newName: "IX_Dialogues_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dialogues",
                table: "Dialogues",
                column: "DialogueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogues_Characters_CharacterId",
                table: "Dialogues",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogues_Lessons_LessonId",
                table: "Dialogues",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogues_Characters_CharacterId",
                table: "Dialogues");

            migrationBuilder.DropForeignKey(
                name: "FK_Dialogues_Lessons_LessonId",
                table: "Dialogues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dialogues",
                table: "Dialogues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Dialogues",
                newName: "Dialogue");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Character");

            migrationBuilder.RenameIndex(
                name: "IX_Dialogues_LessonId",
                table: "Dialogue",
                newName: "IX_Dialogue_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Dialogues_CharacterId",
                table: "Dialogue",
                newName: "IX_Dialogue_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dialogue",
                table: "Dialogue",
                column: "DialogueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogue_Character_CharacterId",
                table: "Dialogue",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogue_Lessons_LessonId",
                table: "Dialogue",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
