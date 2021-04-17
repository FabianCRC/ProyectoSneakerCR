using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.DataModel
{
    public partial class SneakersCRContext : DbContext
    {
        public SneakersCRContext()
        {
        }

        public SneakersCRContext(DbContextOptions<SneakersCRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CategoriaProductos> CategoriaProductos { get; set; }
        public virtual DbSet<CorreoTienda> CorreoTienda { get; set; }
        public virtual DbSet<MarcaProductos> MarcaProductos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TelefonoTienda> TelefonoTienda { get; set; }
        public virtual DbSet<Tiendas> Tiendas { get; set; }
        public virtual DbSet<UbicacionTienda> UbicacionTienda { get; set; }
        public virtual DbSet<UsuarioTienda> UsuarioTienda { get; set; }
        public virtual DbSet<ValoracionTienda> ValoracionTienda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-NTJ8C71K;Database=SneakersCR;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

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

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__id_ca__2C3393D0");

                entity.HasOne(d => d.IdMarcaProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarcaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__id_ma__2B3F6F97");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productos__id_ti__2A4B4B5E");
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

                entity.HasOne(d => d.IdTiendaNavigation)
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
                    .HasName("PK__usuario___12CDCE69A394A8E4");

                entity.ToTable("usuario_tienda");

                entity.Property(e => e.IdUsuarioTienda)
                    .HasColumnName("id_usuario_tienda")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdTienda)
                    .HasColumnName("id_tienda")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("id_usuario")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.UsuarioTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario_t__id_ti__0D7A0286");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioTienda)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario_t__id_us__0C85DE4D");
            });

            modelBuilder.Entity<ValoracionTienda>(entity =>
            {
                entity.HasKey(e => e.IdValoracion)
                    .HasName("PK__valoraci__1861B249DEE6D53D");

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
                    .IsRequired()
                    .HasColumnName("id_usuario")
                    .HasMaxLength(450);

                entity.Property(e => e.Valoracion)
                    .HasColumnName("valoracion")
                    .HasColumnType("numeric(3, 1)");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.ValoracionTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__valoracio__id_ti__09A971A2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ValoracionTienda)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__valoracio__id_us__08B54D69");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
