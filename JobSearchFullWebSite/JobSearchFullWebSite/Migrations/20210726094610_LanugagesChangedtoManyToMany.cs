using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchFullWebSite.Migrations
{
    public partial class LanugagesChangedtoManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CandidateKnowingLanguages");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "CandidateKnowingLanguages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CandidateKnowingLanguages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKnowingLanguages_CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages",
                column: "CandidateKnowingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKnowingLanguages_LanguageId",
                table: "CandidateKnowingLanguages",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                table: "CandidateKnowingLanguages",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_CandidateKnowingLanguages_CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages",
                column: "CandidateKnowingLanguageId",
                principalTable: "CandidateKnowingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_Languages_LanguageId",
                table: "CandidateKnowingLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_CandidateKnowingLanguages_CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_Languages_LanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_CandidateKnowingLanguages_CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropIndex(
                name: "IX_CandidateKnowingLanguages_LanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropColumn(
                name: "CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "CandidateKnowingLanguages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CandidateKnowingLanguages",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                table: "CandidateKnowingLanguages",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
