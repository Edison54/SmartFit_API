using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartFit_API.Models
{
    public partial class SmartFitContext : DbContext
    {
        public SmartFitContext()
        {
        }

        public SmartFitContext(DbContextOptions<SmartFitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExercisesMachine> ExercisesMachines { get; set; } = null!;
        public virtual DbSet<Measure> Measures { get; set; } = null!;
        public virtual DbSet<MusclesMeasure> MusclesMeasures { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=DESKTOP-AIMH9J6;DATABASE=SmartFit; INTEGRATED SECURITY=TRUE; User Id=;Password=;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExercisesMachine>(entity =>
            {
                entity.HasKey(e => e.IdEjercicio)
                    .HasName("PK__Exercise__7BB4D9DBAAE1E1D1");

                entity.ToTable("Exercises_Machines");

                entity.Property(e => e.IdEjercicio).HasColumnName("id_ejercicio");

                entity.Property(e => e.CantidadRepeticiones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cantidad_repeticiones");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.NameExercise)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name_exercise");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Tiempo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tiempo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ExercisesMachines)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exercises__id_Us__31EC6D26");
            });

            modelBuilder.Entity<Measure>(entity =>
            {
                entity.HasKey(e => e.IdMeasure)
                    .HasName("PK__measures__EC2028C2CF2A152D");

                entity.ToTable("measures");

                entity.Property(e => e.IdMeasure).HasColumnName("id_measure");

                entity.Property(e => e.Altura)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("altura");

                entity.Property(e => e.Grasa)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("grasa");

                entity.Property(e => e.GrasaViseral)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("grasa_viseral");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Peso)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("peso");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Measures)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__measures__id_Usu__2F10007B");
            });

            modelBuilder.Entity<MusclesMeasure>(entity =>
            {
                entity.HasKey(e => e.IdMuscle)
                    .HasName("PK__muscles___F16EA7A68BBC0A16");

                entity.ToTable("muscles_measures");

                entity.Property(e => e.IdMuscle).HasColumnName("id_muscle");

                entity.Property(e => e.FechaMedida)
                    .HasColumnType("date")
                    .HasColumnName("fecha_medida")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Medida)
                    .HasColumnType("decimal(5, 1)")
                    .HasColumnName("medida");

                entity.Property(e => e.Musculo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("musculo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.MusclesMeasures)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__muscles_m__id_Us__2B3F6F97");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pagos__0941B074BD4A9545");

                entity.Property(e => e.IdPago).HasColumnName("id_pago");

                entity.Property(e => e.Estado)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pagos__id_Usuari__286302EC");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__8E901EAA277114AA");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Rol)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rol")
                    .HasDefaultValueSql("('Usuario')");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
