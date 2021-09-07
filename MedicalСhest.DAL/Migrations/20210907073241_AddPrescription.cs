using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalСhest.DAL.Migrations
{
    public partial class AddPrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Medications_MedicationId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_MedicationId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "DosesPerDay",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "DurationInDays",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "MedicationId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "NeedPrescriptions",
                table: "Medications",
                newName: "NeedLicense");

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    DosesPerDay = table.Column<int>(type: "int", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicationId",
                table: "Prescriptions",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ReceiptId",
                table: "Prescriptions",
                column: "ReceiptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "NeedLicense",
                table: "Medications",
                newName: "NeedPrescriptions");

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DosesPerDay",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationInDays",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MedicationId",
                table: "Receipts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_MedicationId",
                table: "Receipts",
                column: "MedicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Medications_MedicationId",
                table: "Receipts",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
