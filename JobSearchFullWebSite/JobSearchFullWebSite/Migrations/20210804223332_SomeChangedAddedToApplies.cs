using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchFullWebSite.Migrations
{
    public partial class SomeChangedAddedToApplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_CandidateKnowingLanguages_CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_Candidates_CandidateId",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_Employers_EmployerId",
                table: "Follower");

            migrationBuilder.DropIndex(
                name: "IX_Employers_AppUserId",
                table: "Employers");

            //migrationBuilder.DropIndex(
            //    name: "IX_Candidates_AppUserId",
            //    table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_CandidateKnowingLanguages_CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follower",
                table: "Follower");

            migrationBuilder.DropColumn(
                name: "CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Applies");

            migrationBuilder.RenameTable(
                name: "Follower",
                newName: "Followers");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_EmployerId",
                table: "Followers",
                newName: "IX_Followers_EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_CandidateId",
                table: "Followers",
                newName: "IX_Followers_CandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Testimonials",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Testimonials",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Testimonials",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlueText",
                table: "Testimonials",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeaderResponsiveLogo",
                table: "Settings",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FooterLogo",
                table: "Settings",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Admins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_AppUserId",
                table: "Employers",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Candidates_AppUserId",
            //    table: "Candidates",
            //    column: "AppUserId",
            //    unique: true,
            //    filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Candidates_CandidateId",
                table: "Followers",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Employers_EmployerId",
                table: "Followers",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Candidates_CandidateId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Employers_EmployerId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_AppUserId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_AppUserId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "Follower");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_EmployerId",
                table: "Follower",
                newName: "IX_Follower_EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_CandidateId",
                table: "Follower",
                newName: "IX_Follower_CandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Testimonials",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Testimonials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Testimonials",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "BlueText",
                table: "Testimonials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "HeaderResponsiveLogo",
                table: "Settings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "FooterLogo",
                table: "Settings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Applies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follower",
                table: "Follower",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_AppUserId",
                table: "Employers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_AppUserId",
                table: "Candidates",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKnowingLanguages_CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages",
                column: "CandidateKnowingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_CandidateKnowingLanguages_CandidateKnowingLanguageId",
                table: "CandidateKnowingLanguages",
                column: "CandidateKnowingLanguageId",
                principalTable: "CandidateKnowingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_Candidates_CandidateId",
                table: "Follower",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_Employers_EmployerId",
                table: "Follower",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
