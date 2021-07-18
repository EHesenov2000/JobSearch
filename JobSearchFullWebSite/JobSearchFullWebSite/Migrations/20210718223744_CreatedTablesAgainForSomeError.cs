using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchFullWebSite.Migrations
{
    public partial class CreatedTablesAgainForSomeError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveUsers = table.Column<int>(nullable: false),
                    Positions = table.Column<int>(nullable: false),
                    Shared = table.Column<int>(nullable: false),
                    AboutContentTextEditor = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutSponsors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SponsorImage = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(maxLength: 100, nullable: false),
                    FullImage = table.Column<string>(maxLength: 100, nullable: false),
                    DescriptionTextEditor = table.Column<string>(maxLength: 1000, nullable: false),
                    BackBlueTextHead = table.Column<string>(maxLength: 200, nullable: true),
                    BackBlueTextFoot = table.Column<string>(maxLength: 50, nullable: true),
                    ContainerImage = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 30, nullable: false),
                    Image = table.Column<string>(maxLength: 100, nullable: false),
                    Latitude = table.Column<string>(maxLength: 20, nullable: false),
                    Longitude = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HowWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 150, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HowWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderLogo = table.Column<string>(maxLength: 150, nullable: true),
                    HeaderResponsiveLogo = table.Column<string>(maxLength: 150, nullable: true),
                    FooterLogo = table.Column<string>(maxLength: 150, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Location = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    FacebookUrl = table.Column<string>(maxLength: 150, nullable: false),
                    TwitterUrl = table.Column<string>(maxLength: 150, nullable: false),
                    InstagramUrl = table.Column<string>(maxLength: 150, nullable: false),
                    LinkedinUrl = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 100, nullable: false),
                    BlueText = table.Column<string>(maxLength: 50, nullable: true),
                    Content = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Position = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 100, nullable: false),
                    AboutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutImages_Abouts_AboutId",
                        column: x => x.AboutId,
                        principalTable: "Abouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogItemLearns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Learn = table.Column<string>(maxLength: 100, nullable: false),
                    BlogItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItemLearns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogItemLearns_BlogItems_BlogItemId",
                        column: x => x.BlogItemId,
                        principalTable: "BlogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogItemRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requirement = table.Column<string>(maxLength: 100, nullable: false),
                    BlogItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItemRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogItemRequirements_BlogItems_BlogItemId",
                        column: x => x.BlogItemId,
                        principalTable: "BlogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FoundedDate = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    FacebookUrl = table.Column<string>(maxLength: 100, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 100, nullable: true),
                    LinkedinUrl = table.Column<string>(maxLength: 100, nullable: true),
                    InstagramUrl = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyContent = table.Column<string>(maxLength: 1500, nullable: false),
                    Website = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
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
                    IsPoster = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "EmployerContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Message = table.Column<string>(maxLength: 500, nullable: false),
                    EmployerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerContacts_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployerImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 100, nullable: false),
                    IsPoster = table.Column<bool>(nullable: false),
                    EmployerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerImages_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    OfferedMaxSalary = table.Column<int>(nullable: false),
                    OfferedMinSalary = table.Column<int>(nullable: false),
                    OfferedSalaryForTime = table.Column<int>(nullable: false),
                    JobType = table.Column<int>(nullable: false),
                    IsUrgent = table.Column<bool>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    RequiredExperience = table.Column<int>(nullable: false),
                    CareerLevel = table.Column<int>(nullable: false),
                    JobContentTextEditor = table.Column<string>(maxLength: 2000, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    EmployerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Message = table.Column<string>(maxLength: 500, nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobContacts_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 100, nullable: false),
                    IsPoster = table.Column<bool>(nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobImages_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
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

            migrationBuilder.CreateIndex(
                name: "IX_AboutImages_AboutId",
                table: "AboutImages",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItemLearns_BlogItemId",
                table: "BlogItemLearns",
                column: "BlogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItemRequirements_BlogItemId",
                table: "BlogItemRequirements",
                column: "BlogItemId");

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
                name: "IX_EmployerContacts_EmployerId",
                table: "EmployerContacts",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerImages_EmployerId",
                table: "EmployerImages",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_CategoryId",
                table: "Employers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_CityId",
                table: "Employers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobContacts_JobId",
                table: "JobContacts",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobImages_JobId",
                table: "JobImages",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequiredLanguages_JobId",
                table: "JobRequiredLanguages",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CityId",
                table: "Jobs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs",
                column: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutImages");

            migrationBuilder.DropTable(
                name: "AboutSponsors");

            migrationBuilder.DropTable(
                name: "BlogItemLearns");

            migrationBuilder.DropTable(
                name: "BlogItemRequirements");

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
                name: "EmployerContacts");

            migrationBuilder.DropTable(
                name: "EmployerImages");

            migrationBuilder.DropTable(
                name: "HowWorks");

            migrationBuilder.DropTable(
                name: "JobContacts");

            migrationBuilder.DropTable(
                name: "JobImages");

            migrationBuilder.DropTable(
                name: "JobRequiredLanguages");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "BlogItems");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
