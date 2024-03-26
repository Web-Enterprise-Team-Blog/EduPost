using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class _03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61521b0c-13fb-44a0-b67c-f753cf71bba5", "AQAAAAIAAYagAAAAEBdGZDqY/P61BXsLDI0xzUn5ZqaiwOMGgzYjGpoJKv8eMggcDxUGL2GZcoVXetrUpA==", "P326W733E2RXH66PPK4ZYOQRQREJTMUD" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c8dc33b-557d-45e3-89f6-da80099cfb11", "AQAAAAIAAYagAAAAEOeiGoBGZzflrpnCe+RN6VHV0k7kEbpLSInaNkS8Nz5kZ5/0eiuzYhJ6f1OCgDnlMA==", "N4WB5UFKHKL7A77NYK766NIJDZJVQWIP" });
        }
    }
}
