using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTJobMatch.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase12_16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Postion",
                table: "Jobs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Postion",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
