using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BKS.VacancyMagic.Backend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SmallChangesInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecretKey",
                table: "ServiceAuthorizations",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ServiceAuthorizations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "SecretKey",
                value: "v3.r.137902953.2438a9ca6677da093e5068ff8b52c65119ccbd0e.db749930ceec732297cc24f351ef405d053c4466");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecretKey",
                table: "ServiceAuthorizations");
        }
    }
}
