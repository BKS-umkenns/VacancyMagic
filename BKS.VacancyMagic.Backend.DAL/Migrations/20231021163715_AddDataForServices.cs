using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BKS.VacancyMagic.Backend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDataForServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "SuperJob" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
