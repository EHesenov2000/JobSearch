using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchFullWebSite.Migrations
{
    public partial class JobCommmentTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobComments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobComments_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobComments_AppUserId",
                table: "JobComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobComments_JobId",
                table: "JobComments",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobComments");
        }
    }
}
