using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchFullWebSite.Migrations
{
    public partial class ApplyTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(nullable: true),
                    JobId = table.Column<int>(nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 20, nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: true),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    ApplyStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applies_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applies_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applies_AppUserId",
                table: "Applies",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Applies_JobId",
                table: "Applies",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applies");
        }
    }
}
