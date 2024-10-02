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

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedores { get; set; }

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

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("pk_producto_codigoProducto");

            entity.ToTable("producto");

            entity.Property(e => e.CodigoProducto).HasColumnName("codigoProducto");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("cantidad");
            entity.Property(e => e.Codigo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.CodigoCategoria).HasColumnName("codigoCategoria");
            entity.Property(e => e.CodigoMarca).HasColumnName("codigoMarca");
            entity.Property(e => e.CodigoPresentacion).HasColumnName("codigoPresentacion");
            entity.Property(e => e.CodigoProveedor).HasColumnName("codigoProveedor");
            entity.Property(e => e.CodigoTipoProducto).HasColumnName("codigoTipoProducto");
            entity.Property(e => e.Costo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("costo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioDocena)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("precioDocena");
            entity.Property(e => e.PrecioMayorista)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("precioMayorista");
            entity.Property(e => e.PrecioUnidad)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("precioUnidad");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_categoria_codigoCategoria");

            entity.HasOne(d => d.CodigoMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_marca_codigoMarca");

            entity.HasOne(d => d.CodigoPresentacionNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoPresentacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_presentacion_codigoPresentacion");

            entity.HasOne(d => d.CodigoProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_proveedor_codigoProveedor");

            entity.HasOne(d => d.CodigoTipoProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoTipoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_tipoProducto_codigoTipoProducto");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.CodigoProveedor).HasName("pk_proveedore_codigoProveedor");

            entity.ToTable("proveedor");

            entity.Property(e => e.CodigoProveedor).HasColumnName("codigoProveedor");
            entity.Property(e => e.CodigoCategoria).HasColumnName("codigoCategoria");
            entity.Property(e => e.Direccion)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreBanco)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("nombreBanco");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("nombreProveedor");
            entity.Property(e => e.NumeroCuenta)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numeroCuenta");
            entity.Property(e => e.Telefono)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.CodigoCategoriaN).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.CodigoCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_proveedore_categoria_codigoCategoria");
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
