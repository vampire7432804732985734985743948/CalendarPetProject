using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarPetProject.Migrations
{
    /// <inheritdoc />
    public partial class FixAccountData5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "UserProfileData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "UserProfileData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "UserProfileData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileDescription",
                table: "UserProfileData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "X",
                table: "UserProfileData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "UserProfileData",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "UserProfileData");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "UserProfileData");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "UserProfileData");

            migrationBuilder.DropColumn(
                name: "ProfileDescription",
                table: "UserProfileData");

            migrationBuilder.DropColumn(
                name: "X",
                table: "UserProfileData");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "UserProfileData");
        }
    }
}
