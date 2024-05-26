using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToCep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Donor");

            migrationBuilder.AddColumn<string>(
                name: "Address_Cep",
                table: "Donor",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Cep",
                table: "Donor");

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Donor",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }
    }
}
