using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarPetProject.Migrations
{
    /// <inheritdoc />
    public partial class AddCuspomerPhysicalParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CaseClosingTime",
                table: "ContactSupportCases",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "CustomerBodyParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    FatPercentage = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    PhysicalActivityLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityCoefficient = table.Column<double>(type: "float", nullable: false),
                    FFM = table.Column<double>(type: "float", nullable: false),
                    BMR = table.Column<double>(type: "float", nullable: false),
                    TDEE = table.Column<double>(type: "float", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBodyParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerBodyParameters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBodyParameters_UserId",
                table: "CustomerBodyParameters",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerBodyParameters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CaseClosingTime",
                table: "ContactSupportCases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
