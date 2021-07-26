using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchFullWebSite.Migrations
{
    public partial class newTableCretaed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_Languages_LanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Cities_CityId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Positions_PositionId",
                table: "Candidates");

            migrationBuilder.AlterColumn<int>(
                name: "WaitingSalary",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryForTime",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Qualification",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Candidates",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthdayDate",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Candidates",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "CandidateKnowingLanguages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "CandidateKnowingLanguages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                table: "CandidateKnowingLanguages",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_Languages_LanguageId",
                table: "CandidateKnowingLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Cities_CityId",
                table: "Candidates",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Positions_PositionId",
                table: "Candidates",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKnowingLanguages_Languages_LanguageId",
                table: "CandidateKnowingLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Cities_CityId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Positions_PositionId",
                table: "Candidates");

            migrationBuilder.AlterColumn<int>(
                name: "WaitingSalary",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalaryForTime",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Qualification",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthdayDate",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "CandidateKnowingLanguages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "CandidateKnowingLanguages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                table: "CandidateKnowingLanguages",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateKnowingLanguages_Languages_LanguageId",
                table: "CandidateKnowingLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Cities_CityId",
                table: "Candidates",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Positions_PositionId",
                table: "Candidates",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
