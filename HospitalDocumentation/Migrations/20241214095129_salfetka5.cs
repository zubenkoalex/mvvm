using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalDocumentation.Migrations
{
    /// <inheritdoc />
    public partial class salfetka5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Drugstore__DrugI__46E78A0C",
                table: "DrugstoreEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Appoi__4BAC3F29",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Docto__4AB81AF0",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Labor__4E88ABD4",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Medic__4CA06362",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Patie__49C3F6B7",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Recip__4D94879B",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__RecipeEnt__DrugI__440B1D61",
                table: "RecipeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__RecipeEn__3214EC07CE0047DA",
                table: "RecipeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PatientE__3214EC07C9641337",
                table: "PatientEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MedicalR__3214EC07107CC68F",
                table: "MedicalRecordEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MedicalH__3214EC075A8E023E",
                table: "MedicalHistoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Laborato__3214EC072C0AA531",
                table: "LaboratoryTestEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Drugstor__3214EC074121256B",
                table: "DrugstoreEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DrugEnti__3214EC07A43567EF",
                table: "DrugEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DoctorEn__3214EC07183100D6",
                table: "DoctorEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Appointm__3214EC07956DB0B4",
                table: "AppointmentRecordEntity");

            migrationBuilder.AlterColumn<int>(
                name: "DrugID",
                table: "DrugstoreEntity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "DoctorEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__RecipeEn__3214EC074B112906",
                table: "RecipeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PatientE__3214EC071FD18CED",
                table: "PatientEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MedicalR__3214EC079B9E550D",
                table: "MedicalRecordEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MedicalH__3214EC077502E585",
                table: "MedicalHistoryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Laborato__3214EC07E1D8819B",
                table: "LaboratoryTestEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Drugstor__3214EC078713B7DB",
                table: "DrugstoreEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DrugEnti__3214EC07D9052C17",
                table: "DrugEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DoctorEn__3214EC0792DF5279",
                table: "DoctorEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Appointm__3214EC0788280889",
                table: "AppointmentRecordEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CarDoctorsEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Generation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Approximate_price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarDocto__3214EC07AEA1BF8D", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEntity_CarID",
                table: "DoctorEntity",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK__DoctorEnt__CarID__5629CD9C",
                table: "DoctorEntity",
                column: "CarID",
                principalTable: "CarDoctorsEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Drugstore__DrugI__4E88ABD4",
                table: "DrugstoreEntity",
                column: "DrugID",
                principalTable: "DrugEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Appoi__5AEE82B9",
                table: "MedicalRecordEntity",
                column: "AppointmentRecordID",
                principalTable: "AppointmentRecordEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Docto__59FA5E80",
                table: "MedicalRecordEntity",
                column: "DoctorID",
                principalTable: "DoctorEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Labor__5DCAEF64",
                table: "MedicalRecordEntity",
                column: "LaboratoryTestID",
                principalTable: "LaboratoryTestEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Medic__5BE2A6F2",
                table: "MedicalRecordEntity",
                column: "MedicalHistoryID",
                principalTable: "MedicalHistoryEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Patie__59063A47",
                table: "MedicalRecordEntity",
                column: "PatientID",
                principalTable: "PatientEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Recip__5CD6CB2B",
                table: "MedicalRecordEntity",
                column: "RecipeID",
                principalTable: "RecipeEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__RecipeEnt__DrugI__4BAC3F29",
                table: "RecipeEntity",
                column: "DrugID",
                principalTable: "DrugEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__DoctorEnt__CarID__5629CD9C",
                table: "DoctorEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__Drugstore__DrugI__4E88ABD4",
                table: "DrugstoreEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Appoi__5AEE82B9",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Docto__59FA5E80",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Labor__5DCAEF64",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Medic__5BE2A6F2",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Patie__59063A47",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__MedicalRe__Recip__5CD6CB2B",
                table: "MedicalRecordEntity");

            migrationBuilder.DropForeignKey(
                name: "FK__RecipeEnt__DrugI__4BAC3F29",
                table: "RecipeEntity");

            migrationBuilder.DropTable(
                name: "CarDoctorsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__RecipeEn__3214EC074B112906",
                table: "RecipeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PatientE__3214EC071FD18CED",
                table: "PatientEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MedicalR__3214EC079B9E550D",
                table: "MedicalRecordEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MedicalH__3214EC077502E585",
                table: "MedicalHistoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Laborato__3214EC07E1D8819B",
                table: "LaboratoryTestEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Drugstor__3214EC078713B7DB",
                table: "DrugstoreEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DrugEnti__3214EC07D9052C17",
                table: "DrugEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DoctorEn__3214EC0792DF5279",
                table: "DoctorEntity");

            migrationBuilder.DropIndex(
                name: "IX_DoctorEntity_CarID",
                table: "DoctorEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Appointm__3214EC0788280889",
                table: "AppointmentRecordEntity");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "DoctorEntity");

            migrationBuilder.AlterColumn<int>(
                name: "DrugID",
                table: "DrugstoreEntity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__RecipeEn__3214EC07CE0047DA",
                table: "RecipeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PatientE__3214EC07C9641337",
                table: "PatientEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MedicalR__3214EC07107CC68F",
                table: "MedicalRecordEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MedicalH__3214EC075A8E023E",
                table: "MedicalHistoryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Laborato__3214EC072C0AA531",
                table: "LaboratoryTestEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Drugstor__3214EC074121256B",
                table: "DrugstoreEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DrugEnti__3214EC07A43567EF",
                table: "DrugEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DoctorEn__3214EC07183100D6",
                table: "DoctorEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Appointm__3214EC07956DB0B4",
                table: "AppointmentRecordEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Drugstore__DrugI__46E78A0C",
                table: "DrugstoreEntity",
                column: "DrugID",
                principalTable: "DrugEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Appoi__4BAC3F29",
                table: "MedicalRecordEntity",
                column: "AppointmentRecordID",
                principalTable: "AppointmentRecordEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Docto__4AB81AF0",
                table: "MedicalRecordEntity",
                column: "DoctorID",
                principalTable: "DoctorEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Labor__4E88ABD4",
                table: "MedicalRecordEntity",
                column: "LaboratoryTestID",
                principalTable: "LaboratoryTestEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Medic__4CA06362",
                table: "MedicalRecordEntity",
                column: "MedicalHistoryID",
                principalTable: "MedicalHistoryEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Patie__49C3F6B7",
                table: "MedicalRecordEntity",
                column: "PatientID",
                principalTable: "PatientEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__MedicalRe__Recip__4D94879B",
                table: "MedicalRecordEntity",
                column: "RecipeID",
                principalTable: "RecipeEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__RecipeEnt__DrugI__440B1D61",
                table: "RecipeEntity",
                column: "DrugID",
                principalTable: "DrugEntity",
                principalColumn: "Id");
        }
    }
}
