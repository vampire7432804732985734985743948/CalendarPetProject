using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarPetProject.Migrations
{
    /// <inheritdoc />
    public partial class FixAccountData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileData_AspNetUsers_UserId",
                table: "UserProfileData");

            migrationBuilder.DropIndex(
                name: "IX_UserProfileData_UserId",
                table: "UserProfileData");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserProfileData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserProfileData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileData_UserId",
                table: "UserProfileData",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileData_AspNetUsers_UserId",
                table: "UserProfileData",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
