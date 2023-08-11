using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSliderStatusId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SliderStatusId",
                table: "Sliders",
                type: "int",
                nullable: true,
                defaultValue: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderStatusId",
                table: "Sliders");
        }
    }
}
