using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarPetProject.Migrations
{
    /// <inheritdoc />
    public partial class addcontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactSupportCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSupportCases", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactSupportCases");
        }
    }
}
