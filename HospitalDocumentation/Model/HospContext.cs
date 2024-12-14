using System;
using System.Collections.Generic;
using HospitalDocumentation.Model.Enities;
using Microsoft.EntityFrameworkCore;

namespace HospitalDocumentation.Model;

public partial class HospContext : DbContext
{
    public HospContext()
    {
    }

    public HospContext(DbContextOptions<HospContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppointmentRecordEntity> AppointmentRecordEntities { get; set; }

    public virtual DbSet<CarDoctorsEntity> CarDoctorsEntities { get; set; }

    public virtual DbSet<DoctorEntity> DoctorEntities { get; set; }

    public virtual DbSet<DrugEntity> DrugEntities { get; set; }

    public virtual DbSet<DrugstoreEntity> DrugstoreEntities { get; set; }

    public virtual DbSet<LaboratoryTestEntity> LaboratoryTestEntities { get; set; }

    public virtual DbSet<MedicalHistoryEntity> MedicalHistoryEntities { get; set; }

    public virtual DbSet<MedicalRecordEntity> MedicalRecordEntities { get; set; }

    public virtual DbSet<PatientEntity> PatientEntities { get; set; }

    public virtual DbSet<RecipeEntity> RecipeEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=zubenkoag;Database=Hosp;User=user1;Password=sa;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentRecordEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC0788280889");

            entity.ToTable("AppointmentRecordEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Reason).HasMaxLength(255);
        });

        modelBuilder.Entity<CarDoctorsEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarDocto__3214EC07AEA1BF8D");

            entity.ToTable("CarDoctorsEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApproximatePrice).HasColumnName("Approximate_price");
            entity.Property(e => e.Generation).HasMaxLength(100);
            entity.Property(e => e.Mark).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);
        });

        modelBuilder.Entity<DoctorEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoctorEn__3214EC0792DF5279");

            entity.ToTable("DoctorEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.Speciality).HasMaxLength(100);

            entity.HasOne(d => d.Car).WithMany(p => p.DoctorEntities)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__DoctorEnt__CarID__5629CD9C");
        });

        modelBuilder.Entity<DrugEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DrugEnti__3214EC07D9052C17");

            entity.ToTable("DrugEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dosage).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DrugstoreEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drugstor__3214EC078713B7DB");

            entity.ToTable("DrugstoreEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DrugId).HasColumnName("DrugID");

            entity.HasOne(d => d.Drug).WithMany(p => p.DrugstoreEntities)
                .HasForeignKey(d => d.DrugId)
                .HasConstraintName("FK__Drugstore__DrugI__4E88ABD4");
        });

        modelBuilder.Entity<LaboratoryTestEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Laborato__3214EC07E1D8819B");

            entity.ToTable("LaboratoryTestEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<MedicalHistoryEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MedicalH__3214EC077502E585");

            entity.ToTable("MedicalHistoryEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Diagnosis).HasMaxLength(100);
        });

        modelBuilder.Entity<MedicalRecordEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MedicalR__3214EC079B9E550D");

            entity.ToTable("MedicalRecordEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AppointmentRecordId).HasColumnName("AppointmentRecordID");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.LaboratoryTestId).HasColumnName("LaboratoryTestID");
            entity.Property(e => e.MedicalHistoryId).HasColumnName("MedicalHistoryID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            entity.HasOne(d => d.AppointmentRecord).WithMany(p => p.MedicalRecordEntities)
                .HasForeignKey(d => d.AppointmentRecordId)
                .HasConstraintName("FK__MedicalRe__Appoi__5AEE82B9");

            entity.HasOne(d => d.Doctor).WithMany(p => p.MedicalRecordEntities)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__MedicalRe__Docto__59FA5E80");

            entity.HasOne(d => d.LaboratoryTest).WithMany(p => p.MedicalRecordEntities)
                .HasForeignKey(d => d.LaboratoryTestId)
                .HasConstraintName("FK__MedicalRe__Labor__5DCAEF64");

            entity.HasOne(d => d.MedicalHistory).WithMany(p => p.MedicalRecordEntities)
                .HasForeignKey(d => d.MedicalHistoryId)
                .HasConstraintName("FK__MedicalRe__Medic__5BE2A6F2");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalRecordEntities)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__MedicalRe__Patie__59063A47");

            entity.HasOne(d => d.Recipe).WithMany(p => p.MedicalRecordEntities)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__MedicalRe__Recip__5CD6CB2B");
        });

        modelBuilder.Entity<PatientEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PatientE__3214EC071FD18CED");

            entity.ToTable("PatientEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.Sex).HasMaxLength(100);
        });

        modelBuilder.Entity<RecipeEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RecipeEn__3214EC074B112906");

            entity.ToTable("RecipeEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DrugId).HasColumnName("DrugID");
            entity.Property(e => e.Duration).HasMaxLength(100);

            entity.HasOne(d => d.Drug).WithMany(p => p.RecipeEntities)
                .HasForeignKey(d => d.DrugId)
                .HasConstraintName("FK__RecipeEnt__DrugI__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
