using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Model
{
    public partial class DBGestionPruebasContext : DbContext
    {
        public DBGestionPruebasContext()
        {
        }

        public DBGestionPruebasContext(DbContextOptions<DBGestionPruebasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspirante> Aspirantes { get; set; } = null!;
        public virtual DbSet<AspirantePruebaSeleccion> AspirantePruebaSeleccions { get; set; } = null!;
        public virtual DbSet<EstadoPrueba> EstadoPruebas { get; set; } = null!;
        public virtual DbSet<LenguajeProgramacion> LenguajeProgramacions { get; set; } = null!;
        public virtual DbSet<Nivel> Nivels { get; set; } = null!;
        public virtual DbSet<Pregunta> Preguntas { get; set; } = null!;
        public virtual DbSet<PreguntasPruebaSeleccion> PreguntasPruebaSeleccions { get; set; } = null!;
        public virtual DbSet<PruebaSeleccion> PruebaSeleccions { get; set; } = null!;
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; } = null!;
        public virtual DbSet<TipoPrueba> TipoPruebas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReporteAspirante>().HasNoKey();

            modelBuilder.Entity<Aspirante>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Aspirantes)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Aspirante__IdTip__2D27B809");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.Aspirantes)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Aspirante__IdUsu__2F10007B");
            });

            modelBuilder.Entity<AspirantePruebaSeleccion>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdAspirante, e.IdPruebaSeleccion })
                    .HasName("PK__Aspirant__2570B9156DC181F4");

                entity.ToTable("AspirantePruebaSeleccion");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
                entity.Property(e => e.Calificacion).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.IdAspiranteNavigation)
                    .WithMany(p => p.AspirantePruebaSeleccions)
                    .HasForeignKey(d => d.IdAspirante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Aspirante__IdAsp__440B1D61");

                entity.HasOne(d => d.IdPruebaSeleccionNavigation)
                    .WithMany(p => p.AspirantePruebaSeleccions)
                    .HasForeignKey(d => d.IdPruebaSeleccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Aspirante__IdPru__44FF419A");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.AspirantePruebaSeleccions)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Aspirante__IdUsu__45F365D3");

                entity.HasOne(d => d.IdEstadoPruebaNavigation)
                    .WithMany(p => p.AspirantePruebaSeleccions)
                    .HasForeignKey(d => d.IdEstadoPrueba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Aspirante__IdEst__2E1BDC42");
            });

            modelBuilder.Entity<EstadoPrueba>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(256);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.EstadoPruebas)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EstadoPru__IdUsu__2A4B4B5E");
            });

            modelBuilder.Entity<LenguajeProgramacion>(entity =>
            {
                entity.ToTable("LenguajeProgramacion");

                entity.Property(e => e.Descripcion).HasMaxLength(256);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.LenguajeProgramacions)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LenguajeP__IdUsu__34C8D9D1");
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.ToTable("Nivel");

                entity.Property(e => e.Descripcion).HasMaxLength(256);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.Nivels)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nivel__IdUsuario__37A5467C");
            });

            modelBuilder.Entity<Pregunta>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdLenguajeProgramacionNavigation)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.IdLenguajeProgramacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preguntas__IdLen__403A8C7D");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preguntas__IdUsu__412EB0B6");
            });

            modelBuilder.Entity<PreguntasPruebaSeleccion>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdPregunta, e.IdPruebaSeleccion })
                    .HasName("PK__Pregunta__52BAB32837B5C859");

                entity.ToTable("PreguntasPruebaSeleccion");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.PreguntasPruebaSeleccions)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preguntas__IdPre__48CFD27E");

                entity.HasOne(d => d.IdPruebaSeleccionNavigation)
                    .WithMany(p => p.PreguntasPruebaSeleccions)
                    .HasForeignKey(d => d.IdPruebaSeleccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preguntas__IdPru__49C3F6B7");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.PreguntasPruebaSeleccions)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preguntas__IdUsu__4AB81AF0");
            });

            modelBuilder.Entity<PruebaSeleccion>(entity =>
            {
                entity.ToTable("PruebaSeleccion");

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.NombreDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLenguajeProgramacionNavigation)
                    .WithMany(p => p.PruebaSeleccions)
                    .HasForeignKey(d => d.IdLenguajeProgramacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PruebaSel__IdLen__3B75D760");

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.PruebaSeleccions)
                    .HasForeignKey(d => d.IdNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PruebaSel__IdNiv__3C69FB99");

                entity.HasOne(d => d.IdTipoPruebaNavigation)
                    .WithMany(p => p.PruebaSeleccions)
                    .HasForeignKey(d => d.IdTipoPrueba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PruebaSel__IdTip__3A81B327");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.PruebaSeleccions)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PruebaSel__IdUsu__3D5E1FD2");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(256);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.TipoDocumentos)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TipoDocum__IdUsu__276EDEB3");
            });

            modelBuilder.Entity<TipoPrueba>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(256);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.TipoPruebas)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TipoPrueb__IdUsu__31EC6D26");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.NombreUsuario).HasMaxLength(256);

                entity.HasOne(d => d.IdUsuarioActualizacionNavigation)
                    .WithMany(p => p.InverseIdUsuarioActualizacionNavigation)
                    .HasForeignKey(d => d.IdUsuarioActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IdUsua__24927208");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
