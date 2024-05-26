using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddressToBrazilianWay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Donor",
                newName: "Address_Uf");

            migrationBuilder.RenameColumn(
                name: "Address_PublicArea",
                table: "Donor",
                newName: "Address_Logradouro");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Donor",
                newName: "Address_Localidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Uf",
                table: "Donor",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "Address_Logradouro",
                table: "Donor",
                newName: "Address_PublicArea");

            migrationBuilder.RenameColumn(
                name: "Address_Localidade",
                table: "Donor",
                newName: "Address_City");
        }
    }
}
