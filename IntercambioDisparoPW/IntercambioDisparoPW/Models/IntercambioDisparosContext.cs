using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IntercambioDisparoPW.Models
{
    public partial class IntercambioDisparosContext : DbContext
    {
        public IntercambioDisparosContext()
        {
        }

        public IntercambioDisparosContext(DbContextOptions<IntercambioDisparosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coordenada> Coordenadas { get; set; } = null!;
        public virtual DbSet<IntercambioDeDisparo> IntercambioDeDisparos { get; set; } = null!;
        public virtual DbSet<Participante> Participantes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AppConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordenada>(entity =>
            {
                entity.HasKey(e => e.IdCoordenadas)
                    .HasName("PK__coordena__C9F5ED0BF8F17F18");

                entity.ToTable("coordenadas");

                entity.Property(e => e.IdCoordenadas).HasColumnName("id_coordenadas");

                entity.Property(e => e.IdIntercambio).HasColumnName("id_intercambio");

                entity.Property(e => e.Latitud)
                    .HasColumnType("decimal(10, 6)")
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasColumnType("decimal(10, 6)")
                    .HasColumnName("longitud");

                entity.HasOne(d => d.IdIntercambioNavigation)
                    .WithMany(p => p.Coordenada)
                    .HasForeignKey(d => d.IdIntercambio)
                    .HasConstraintName("FK_coordenadas_intercambio_de_disparos");
            });

            modelBuilder.Entity<IntercambioDeDisparo>(entity =>
            {
                entity.HasKey(e => e.IdIntercambio)
                    .HasName("PK__intercam__9444ACDCCD2D6018");

                entity.ToTable("intercambio_de_disparos");

                entity.Property(e => e.IdIntercambio).HasColumnName("id_intercambio");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Lugar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lugar");
            });

            modelBuilder.Entity<Participante>(entity =>
            {
                entity.HasKey(e => e.IdParticipantes)
                    .HasName("PK__particip__9451CD96A30E3FD5");

                entity.ToTable("participantes");

                entity.Property(e => e.IdParticipantes).HasColumnName("id_participantes");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .HasColumnName("cedula")
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.IdCoordenadas).HasColumnName("id_coordenadas");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rol)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.HasOne(d => d.IdCoordenadasNavigation)
                    .WithMany(p => p.Participantes)
                    .HasForeignKey(d => d.IdCoordenadas)
                    .HasConstraintName("FK_participantes_coordenadas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
