using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_applications_JobId",
                table: "applications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_UserId",
                table: "applications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_Jobs_JobId",
                table: "applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_applications_Users_UserId",
                table: "applications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_Jobs_JobId",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_applications_Users_UserId",
                table: "applications");

            migrationBuilder.DropIndex(
                name: "IX_applications_JobId",
                table: "applications");

            migrationBuilder.DropIndex(
                name: "IX_applications_UserId",
                table: "applications");
        }
    }
}
