using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchFullWebSite.Migrations
{
    public partial class SomeTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Jobs_JobId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Employers");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "JobContacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_JobId",
                table: "JobContacts",
                newName: "IX_JobContacts_JobId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Cities",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Cities",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobContacts",
                table: "JobContacts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    Position = table.Column<string>(maxLength: 100, nullable: false),
                    WaitingSalary = table.Column<int>(nullable: false),
                    SalaryForTime = table.Column<int>(nullable: false),
                    BirthdayDate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    AboutCandidateTextEditor = table.Column<string>(maxLength: 1000, nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Qualification = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FacebookUrl = table.Column<string>(maxLength: 100, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 100, nullable: true),
                    LinkedinUrl = table.Column<string>(maxLength: 100, nullable: true),
                    InstagramUrl = table.Column<string>(maxLength: 100, nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobRequiredLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(maxLength: 30, nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequiredLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRequiredLanguages_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateAwardItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Years = table.Column<string>(maxLength: 10, nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAwardItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateAwardItems_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Message = table.Column<string>(maxLength: 500, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateContacts_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateCVs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVName = table.Column<string>(maxLength: 100, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateCVs_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateEducationItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Years = table.Column<string>(maxLength: 10, nullable: false),
                    EducationPlace = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateEducationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateEducationItems_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 100, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateImages_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateKnowingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(maxLength: 30, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateKnowingLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateKnowingLanguages_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CandidateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidateWorkItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    WorkPlace = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateWorkItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateWorkItems_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAwardItems_CandidateId",
                table: "CandidateAwardItems",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateContacts_CandidateId",
                table: "CandidateContacts",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCVs_CandidateId",
                table: "CandidateCVs",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEducationItems_CandidateId",
                table: "CandidateEducationItems",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateImages_CandidateId",
                table: "CandidateImages",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKnowingLanguages_CandidateId",
                table: "CandidateKnowingLanguages",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CityId",
                table: "Candidates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateWorkItems_CandidateId",
                table: "CandidateWorkItems",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequiredLanguages_JobId",
                table: "JobRequiredLanguages",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobContacts_Jobs_JobId",
                table: "JobContacts",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobContacts_Jobs_JobId",
                table: "JobContacts");

            migrationBuilder.DropTable(
                name: "CandidateAwardItems");

            migrationBuilder.DropTable(
                name: "CandidateContacts");

            migrationBuilder.DropTable(
                name: "CandidateCVs");

            migrationBuilder.DropTable(
                name: "CandidateEducationItems");

            migrationBuilder.DropTable(
                name: "CandidateImages");

            migrationBuilder.DropTable(
                name: "CandidateKnowingLanguages");

            migrationBuilder.DropTable(
                name: "CandidateSkills");

            migrationBuilder.DropTable(
                name: "CandidateWorkItems");

            migrationBuilder.DropTable(
                name: "JobRequiredLanguages");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobContacts",
                table: "JobContacts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "JobContacts",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_JobContacts_JobId",
                table: "Contacts",
                newName: "IX_Contacts_JobId");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Jobs_JobId",
                table: "Contacts",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
