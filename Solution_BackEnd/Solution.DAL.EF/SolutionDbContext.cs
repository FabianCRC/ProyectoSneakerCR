using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Solution.DO.Objects;

namespace Solution.DAL.EF
{
    public partial class SolutionDbContext : DbContext
    {
        public SolutionDbContext(DbContextOptions<SolutionDbContext> options) : base(options)
        {

        }

        //DBSet van aqui
        public virtual DbSet<CategoriaProductos> CategoriaProductos { get; set; }
        public virtual DbSet<CorreoTienda> CorreoTienda { get; set; }
        public virtual DbSet<MarcaProductos> MarcaProductos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TelefonoTienda> TelefonoTienda { get; set; }
        public virtual DbSet<Tiendas> Tiendas { get; set; }
        public virtual DbSet<UbicacionTienda> UbicacionTienda { get; set; }
        public virtual DbSet<UsuarioTienda> UsuarioTienda { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ValoracionTienda> ValoracionTienda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //model builder va aqui
            modelBuilder.Entity<CategoriaProductos>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__CD54BC5AE6B98C34");

                entity.ToTable("categoria_productos");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("categoria")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CorreoTienda>(entity =>
            {
                entity.HasKey(e => e.IdCorreo)
                    .HasName("PK__correo_t__D5CABEB384016DE4");

                entity.ToTable("correo_tienda");

                entity.Property(e => e.IdCorreo)
                    .HasColumnName("id_correo")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTienda)
                    .HasColumnName("id_tienda")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.CorreoTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__correo_ti__id_ti__3D5E1FD2");
            });

            modelBuilder.Entity<MarcaProductos>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__marca_pr__7E43E99E74C9E515");

                entity.ToTable("marca_productos");

                entity.Property(e => e.IdMarca)
                    .HasColumnName("id_marca")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MarcaProducto)
                    .IsRequired()
                    .HasColumnName("marca_producto")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__producto__FF341C0D965510C2");

                entity.ToTable("productos");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Anno)
                    .HasColumnName("anno")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.DescripcionPproducto)
                    .IsRequired()
                    .HasColumnName("descripcion_pproducto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdMarcaProducto)
                    .HasColumnName("id_marca_producto")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdTienda)
                    .HasColumnName("id_tienda")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("nombre_producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CategoriaProductos)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__id_ca__2C3393D0");

                entity.HasOne(d => d.MarcaProductos)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarcaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__id_ma__2B3F6F97");

                entity.HasOne(d => d.Tiendas)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__id_ti__2A4B4B5E");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__roles__6ABCB5E061D68A15");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DescripcionRol)
                    .IsRequired()
                    .HasColumnName("descripcion_rol")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TelefonoTienda>(entity =>
            {
                entity.HasKey(e => e.IdTelefono)
                    .HasName("PK__telefono__28CD680245864F14");

                entity.ToTable("telefono_tienda");

                entity.Property(e => e.IdTelefono)
                    .HasColumnName("id_telefono")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTienda)
                    .HasColumnName("id_tienda")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tiendas)
                    .WithMany(p => p.TelefonoTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__telefono___id_ti__31EC6D26");
            });

            modelBuilder.Entity<Tiendas>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PK__tiendas__7C49D73646EF2620");

                entity.ToTable("tiendas");

                entity.Property(e => e.IdTienda)
                    .HasColumnName("id_tienda")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DescripcionTienda)
                    .IsRequired()
                    .HasColumnName("descripcion_tienda")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTienda)
                    .IsRequired()
                    .HasColumnName("nombre_tienda")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UbicacionTienda>(entity =>
            {
                entity.HasKey(e => e.IdUbicacion)
                    .HasName("PK__ubicacio__81BAA5915DA77443");

                entity.ToTable("ubicacion_tienda");

                entity.Property(e => e.IdUbicacion)
                    .HasColumnName("id_ubicacion")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasColumnName("canton")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTienda)
                    .HasColumnName("id_tienda")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasColumnName("provincia")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.UbicacionTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ubicacion__id_ti__2F10007B");
            });

            modelBuilder.Entity<UsuarioTienda>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioTienda)
                    .HasName("PK__usuario___12CDCE69B98F2C9C");

                entity.ToTable("usuario_tienda");

                entity.Property(e => e.IdUsuarioTienda)
                    .HasColumnName("id_usuario_tienda")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdTienda)
                    .HasColumnName("id_tienda")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Tienda)
                    .WithMany(p => p.UsuarioTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario_t__id_ti__412EB0B6");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioTienda)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario_t__id_us__403A8C7D");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__4E3E04AD3FD4CC8F");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnName("contrasena")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoUsuario)
                    .IsRequired()
                    .HasColumnName("correo_usuario")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombre_usuario")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_dbo.Roles_dbo.Usuarios_IdRol");
            });

            modelBuilder.Entity<ValoracionTienda>(entity =>
            {
                entity.HasKey(e => e.IdValoracion)
                    .HasName("PK__valoraci__1861B24956AE353D");

                entity.ToTable("valoracion_tienda");

                entity.Property(e => e.IdValoracion)
                    .HasColumnName("id_valoracion")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnName("comentario")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTienda)
                    .HasColumnName("id_tienda")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Valoracion)
                    .HasColumnName("valoracion")
                    .HasColumnType("numeric(3, 1)");

                entity.HasOne(d => d.Tienda)
                    .WithMany(p => p.ValoracionTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__valoracio__id_ti__3A81B327");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ValoracionTienda)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__valoracio__id_us__398D8EEE");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
