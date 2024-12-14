using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalDocumentation.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentRecordEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Appointm__3214EC07956DB0B4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DoctorEn__3214EC07183100D6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DrugEnti__3214EC07A43567EF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryTestEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Laborato__3214EC072C0AA531", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistoryEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescriptionOfTreatment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MedicalH__3214EC075A8E023E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PatientE__3214EC07C9641337", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugstoreEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DrugID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Drugstor__3214EC074121256B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Drugstore__DrugI__46E78A0C",
                        column: x => x.DrugID,
                        principalTable: "DrugEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DrugID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RecipeEn__3214EC07CE0047DA", x => x.Id);
                    table.ForeignKey(
                        name: "FK__RecipeEnt__DrugI__440B1D61",
                        column: x => x.DrugID,
                        principalTable: "DrugEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecordEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true),
                    AppointmentRecordID = table.Column<int>(type: "int", nullable: true),
                    MedicalHistoryID = table.Column<int>(type: "int", nullable: true),
                    RecipeID = table.Column<int>(type: "int", nullable: true),
                    LaboratoryTestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MedicalR__3214EC07107CC68F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__MedicalRe__Appoi__4BAC3F29",
                        column: x => x.AppointmentRecordID,
                        principalTable: "AppointmentRecordEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__MedicalRe__Docto__4AB81AF0",
                        column: x => x.DoctorID,
                        principalTable: "DoctorEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__MedicalRe__Labor__4E88ABD4",
                        column: x => x.LaboratoryTestID,
                        principalTable: "LaboratoryTestEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__MedicalRe__Medic__4CA06362",
                        column: x => x.MedicalHistoryID,
                        principalTable: "MedicalHistoryEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__MedicalRe__Patie__49C3F6B7",
                        column: x => x.PatientID,
                        principalTable: "PatientEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__MedicalRe__Recip__4D94879B",
                        column: x => x.RecipeID,
                        principalTable: "RecipeEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugstoreEntity_DrugID",
                table: "DrugstoreEntity",
                column: "DrugID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntity_AppointmentRecordID",
                table: "MedicalRecordEntity",
                column: "AppointmentRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntity_DoctorID",
                table: "MedicalRecordEntity",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntity_LaboratoryTestID",
                table: "MedicalRecordEntity",
                column: "LaboratoryTestID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntity_MedicalHistoryID",
                table: "MedicalRecordEntity",
                column: "MedicalHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntity_PatientID",
                table: "MedicalRecordEntity",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntity_RecipeID",
                table: "MedicalRecordEntity",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeEntity_DrugID",
                table: "RecipeEntity",
                column: "DrugID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugstoreEntity");

            migrationBuilder.DropTable(
                name: "MedicalRecordEntity");

            migrationBuilder.DropTable(
                name: "AppointmentRecordEntity");

            migrationBuilder.DropTable(
                name: "DoctorEntity");

            migrationBuilder.DropTable(
                name: "LaboratoryTestEntity");

            migrationBuilder.DropTable(
                name: "MedicalHistoryEntity");

            migrationBuilder.DropTable(
                name: "PatientEntity");

            migrationBuilder.DropTable(
                name: "RecipeEntity");

            migrationBuilder.DropTable(
                name: "DrugEntity");
        }
    }
}
