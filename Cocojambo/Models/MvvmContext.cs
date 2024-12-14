using System;
using System.Collections.Generic;
using Cocojambo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cocojambo.Models;

public partial class MvvmContext : DbContext
{
    public MvvmContext()
    {
    }

    public MvvmContext(DbContextOptions<MvvmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarEntity> CarEntities { get; set; }

    public virtual DbSet<GenerationEntity> GenerationEntities { get; set; }

    public virtual DbSet<MarkEntity> MarkEntities { get; set; }

    public virtual DbSet<ModelEntity> ModelEntities { get; set; }

    public virtual DbSet<PacageEntity> PacageEntities { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=zubenkoag;Database=MVVM;User=user1;Password=sa;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarEntit__3214EC07C6B45D39");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.GenerationId).HasColumnName("GenerationID");
            entity.Property(e => e.MarkId).HasColumnName("MarkID");
            entity.Property(e => e.ModelId).HasColumnName("ModelID");
            entity.Property(e => e.PacageId).HasColumnName("PacageID");
            entity.Property(e => e.Picture).HasMaxLength(255);

            entity.HasOne(d => d.Generation).WithMany(p => p.CarEntities)
                .HasForeignKey(d => d.GenerationId)
                .HasConstraintName("FK__CarEntiti__Gener__412EB0B6");

            entity.HasOne(d => d.Mark).WithMany(p => p.CarEntities)
                .HasForeignKey(d => d.MarkId)
                .HasConstraintName("FK__CarEntiti__MarkI__3F466844");

            entity.HasOne(d => d.Model).WithMany(p => p.CarEntities)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK__CarEntiti__Model__403A8C7D");

            entity.HasOne(d => d.Pacage).WithMany(p => p.CarEntities)
                .HasForeignKey(d => d.PacageId)
                .HasConstraintName("FK__CarEntiti__Pacag__4222D4EF");
        });

        modelBuilder.Entity<GenerationEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Generati__3214EC07F4B7FCEF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NameGeneration).HasMaxLength(22);
        });

        modelBuilder.Entity<MarkEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MarkEnti__3214EC076EEB34C5");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NameMark).HasMaxLength(22);
        });

        modelBuilder.Entity<ModelEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ModelEnt__3214EC0751E504B4");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NameModelCar).HasMaxLength(22);
        });

        modelBuilder.Entity<PacageEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PacageEn__3214EC0791A6B555");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CallColor).HasMaxLength(20);
            entity.Property(e => e.CallType).HasMaxLength(20);
            entity.Property(e => e.DriveType).HasMaxLength(20);
            entity.Property(e => e.EngineVolume).HasMaxLength(6);
            entity.Property(e => e.FuelType).HasMaxLength(20);
            entity.Property(e => e.Kpptype)
                .HasMaxLength(20)
                .HasColumnName("KPPType");
            entity.Property(e => e.NamePacage).HasMaxLength(20);
            entity.Property(e => e.Rudder).HasMaxLength(20);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
