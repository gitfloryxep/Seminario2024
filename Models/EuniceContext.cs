using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ManualidadesEunice.Models;

public partial class EuniceContext : DbContext
{
    public EuniceContext()
    {
    }

    public EuniceContext(DbContextOptions<EuniceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Presentacion> Presentacion { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("Server=localhost; DataBase=EUNICE; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria).HasName("pk_categoria_codigoCategoria");

            entity.ToTable("categoria");

            entity.Property(e => e.CodigoCategoria).HasColumnName("codigoCategoria");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombrecategoria)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("nombrecategoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CodigoCliente).HasName("pk_cliente_codigoCliente");

            entity.ToTable("cliente");

            entity.Property(e => e.CodigoCliente).HasColumnName("codigoCliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.Telefono)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.CodigoMarca).HasName("pk_marca_codigoMarca");

            entity.ToTable("marca");

            entity.Property(e => e.CodigoMarca).HasColumnName("codigoMarca");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("nombreMarca");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.CodigoPresentacion).HasName("pk_presentacion_codigoPresentacion");

            entity.ToTable("presentacion");

            entity.Property(e => e.CodigoPresentacion).HasColumnName("codigoPresentacion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombrePresentacion)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("nombrePresentacion");
        });

        modelBuilder.Entity<TipoProducto>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoProducto).HasName("pk_tipoProducto_codigoTipoProducto");

            entity.ToTable("tipoProducto");

            entity.Property(e => e.CodigoTipoProducto).HasColumnName("codigoTipoProducto");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreTipoProducto)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("nombreTipoProducto");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("pk_usuario_codigoUsuario");

            entity.ToTable("usuario");

            entity.Property(e => e.CodigoUsuario).HasColumnName("codigoUsuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreApellido)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombreApellido");
            entity.Property(e => e.Rol).HasColumnName("rol");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
