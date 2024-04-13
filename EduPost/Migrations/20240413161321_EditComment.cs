using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class EditComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "edited",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "edited",
                table: "Comment");
        }
    }
}
