using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchFullWebSite.Migrations
{
    public partial class newtablecreatedagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
