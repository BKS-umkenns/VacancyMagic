using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BKS.VacancyMagic.Backend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NullableTimetamps_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CreatedAt",
                table: "ReplyHistories",
                type: "bigint",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedAt",
                table: "Replies",
                type: "bigint",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldRowVersion: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CreatedAt",
                table: "ReplyHistories",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedAt",
                table: "Replies",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldRowVersion: true,
                oldNullable: true);
        }
    }
}
