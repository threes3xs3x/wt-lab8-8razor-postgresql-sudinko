using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wt_lab8_8razor_postgresql_sudinko.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Flights");
        }
    }
}
