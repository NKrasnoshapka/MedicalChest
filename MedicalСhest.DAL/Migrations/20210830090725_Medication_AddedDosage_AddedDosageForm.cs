using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalСhest.DAL.Migrations
{
    public partial class Medication_AddedDosage_AddedDosageForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DosageForm",
                table: "Medications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "DosageForm",
                table: "Medications");
        }
    }
}
