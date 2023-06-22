 using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication11.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "bookId", "name", "price" },
                values: new object[,]
                {
                    { 1, "alice harikalar diyarinda", 50 },
                    { 2, "saftirik greg", 100 },
                    { 3, "barbie", 80 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "bookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "bookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "bookId",
                keyValue: 3);
        }
    }
}
