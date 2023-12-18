using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ObtenerListaNombres.Models
{
    public partial class PersonajesSERIEPracticaContext : DbContext
    {
        public PersonajesSERIEPracticaContext()
        {
        }

        public PersonajesSERIEPracticaContext(DbContextOptions<PersonajesSERIEPracticaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonajesNombre> PersonajesNombres { get; set; } = null!;
        public virtual DbSet<UsuarioAdmin> UsuarioAdmins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AppConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonajesNombre>(entity =>
            {
                entity.ToTable("personajesNombre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltText)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("altText");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .IsFixedLength();

                entity.Property(e => e.FechaDeNacimiento)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fecha_de_nacimiento");

                entity.Property(e => e.Habilidad)
                    .HasMaxLength(100)
                    .HasColumnName("habilidad")
                    .IsFixedLength();

                entity.Property(e => e.Imagen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<UsuarioAdmin>(entity =>
            {
                entity.ToTable("UsuarioAdmin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
