using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvch.Migrations
{
    /// <inheritdoc />
    public partial class deletePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "author");

            migrationBuilder.AlterColumn<decimal>(
                name: "Title",
                table: "Zakaz",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Zakaz",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "author",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
