using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class _13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "Article",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "deadline",
                table: "Article",
                newName: "create_date");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "expire_date",
                table: "Article",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expire_date",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Article",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Article",
                newName: "deadline");
        }
    }
}
