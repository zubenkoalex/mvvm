﻿// <auto-generated />
using System;
using HospitalDocumentation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalDocumentation.Migrations
{
    [DbContext(typeof(HospContext))]
    [Migration("20241214095129_salfetka5")]
    partial class salfetka5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.AppointmentRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Appointm__3214EC0788280889");

                    b.ToTable("AppointmentRecordEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.CarDoctorsEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ApproximatePrice")
                        .HasColumnType("int")
                        .HasColumnName("Approximate_price");

                    b.Property<string>("Generation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__CarDocto__3214EC07AEA1BF8D");

                    b.ToTable("CarDoctorsEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.DoctorEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("CarID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__DoctorEn__3214EC0792DF5279");

                    b.HasIndex("CarId");

                    b.ToTable("DoctorEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.DrugEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id")
                        .HasName("PK__DrugEnti__3214EC07D9052C17");

                    b.ToTable("DrugEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.DrugstoreEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("DrugId")
                        .HasColumnType("int")
                        .HasColumnName("DrugID");

                    b.HasKey("Id")
                        .HasName("PK__Drugstor__3214EC078713B7DB");

                    b.HasIndex("DrugId");

                    b.ToTable("DrugstoreEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.LaboratoryTestEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Laborato__3214EC07E1D8819B");

                    b.ToTable("LaboratoryTestEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.MedicalHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionOfTreatment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__MedicalH__3214EC077502E585");

                    b.ToTable("MedicalHistoryEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.MedicalRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("AppointmentRecordId")
                        .HasColumnType("int")
                        .HasColumnName("AppointmentRecordID");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("DoctorID");

                    b.Property<int?>("LaboratoryTestId")
                        .HasColumnType("int")
                        .HasColumnName("LaboratoryTestID");

                    b.Property<int?>("MedicalHistoryId")
                        .HasColumnType("int")
                        .HasColumnName("MedicalHistoryID");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("PatientID");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int")
                        .HasColumnName("RecipeID");

                    b.HasKey("Id")
                        .HasName("PK__MedicalR__3214EC079B9E550D");

                    b.HasIndex("AppointmentRecordId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("LaboratoryTestId");

                    b.HasIndex("MedicalHistoryId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("MedicalRecordEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.PatientEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__PatientE__3214EC071FD18CED");

                    b.ToTable("PatientEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.RecipeEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("DrugId")
                        .HasColumnType("int")
                        .HasColumnName("DrugID");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__RecipeEn__3214EC074B112906");

                    b.HasIndex("DrugId");

                    b.ToTable("RecipeEntity", (string)null);
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.DoctorEntity", b =>
                {
                    b.HasOne("HospitalDocumentation.Model.Enities.CarDoctorsEntity", "Car")
                        .WithMany("DoctorEntities")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK__DoctorEnt__CarID__5629CD9C");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.DrugstoreEntity", b =>
                {
                    b.HasOne("HospitalDocumentation.Model.Enities.DrugEntity", "Drug")
                        .WithMany("DrugstoreEntities")
                        .HasForeignKey("DrugId")
                        .HasConstraintName("FK__Drugstore__DrugI__4E88ABD4");

                    b.Navigation("Drug");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.MedicalRecordEntity", b =>
                {
                    b.HasOne("HospitalDocumentation.Model.Enities.AppointmentRecordEntity", "AppointmentRecord")
                        .WithMany("MedicalRecordEntities")
                        .HasForeignKey("AppointmentRecordId")
                        .HasConstraintName("FK__MedicalRe__Appoi__5AEE82B9");

                    b.HasOne("HospitalDocumentation.Model.Enities.DoctorEntity", "Doctor")
                        .WithMany("MedicalRecordEntities")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK__MedicalRe__Docto__59FA5E80");

                    b.HasOne("HospitalDocumentation.Model.Enities.LaboratoryTestEntity", "LaboratoryTest")
                        .WithMany("MedicalRecordEntities")
                        .HasForeignKey("LaboratoryTestId")
                        .HasConstraintName("FK__MedicalRe__Labor__5DCAEF64");

                    b.HasOne("HospitalDocumentation.Model.Enities.MedicalHistoryEntity", "MedicalHistory")
                        .WithMany("MedicalRecordEntities")
                        .HasForeignKey("MedicalHistoryId")
                        .HasConstraintName("FK__MedicalRe__Medic__5BE2A6F2");

                    b.HasOne("HospitalDocumentation.Model.Enities.PatientEntity", "Patient")
                        .WithMany("MedicalRecordEntities")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK__MedicalRe__Patie__59063A47");

                    b.HasOne("HospitalDocumentation.Model.Enities.RecipeEntity", "Recipe")
                        .WithMany("MedicalRecordEntities")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("FK__MedicalRe__Recip__5CD6CB2B");

                    b.Navigation("AppointmentRecord");

                    b.Navigation("Doctor");

                    b.Navigation("LaboratoryTest");

                    b.Navigation("MedicalHistory");

                    b.Navigation("Patient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.RecipeEntity", b =>
                {
                    b.HasOne("HospitalDocumentation.Model.Enities.DrugEntity", "Drug")
                        .WithMany("RecipeEntities")
                        .HasForeignKey("DrugId")
                        .HasConstraintName("FK__RecipeEnt__DrugI__4BAC3F29");

                    b.Navigation("Drug");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.AppointmentRecordEntity", b =>
                {
                    b.Navigation("MedicalRecordEntities");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.CarDoctorsEntity", b =>
                {
                    b.Navigation("DoctorEntities");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.DoctorEntity", b =>
                {
                    b.Navigation("MedicalRecordEntities");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.DrugEntity", b =>
                {
                    b.Navigation("DrugstoreEntities");

                    b.Navigation("RecipeEntities");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.LaboratoryTestEntity", b =>
                {
                    b.Navigation("MedicalRecordEntities");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.MedicalHistoryEntity", b =>
                {
                    b.Navigation("MedicalRecordEntities");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.PatientEntity", b =>
                {
                    b.Navigation("MedicalRecordEntities");
                });

            modelBuilder.Entity("HospitalDocumentation.Model.Enities.RecipeEntity", b =>
                {
                    b.Navigation("MedicalRecordEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
