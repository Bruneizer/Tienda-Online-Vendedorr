﻿// <auto-generated />
using System;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Persistencia.Migraciones
{
    [DbContext(typeof(TiendaVendedorDbContext))]
    partial class TiendaVendedorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Biblioteca.Dominio.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Producto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CantidadStock")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid?>("TiendaId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("VendedorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("categoriaId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TiendaId");

                    b.HasIndex("VendedorId");

                    b.HasIndex("categoriaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Publicacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("productoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("productoId");

                    b.ToTable("Publicacion");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Tienda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tienda");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Vendedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CUIT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("TiendaId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TiendaId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Producto", b =>
                {
                    b.HasOne("Biblioteca.Dominio.Tienda", null)
                        .WithMany("Productos")
                        .HasForeignKey("TiendaId");

                    b.HasOne("Biblioteca.Dominio.Vendedor", null)
                        .WithMany("productos")
                        .HasForeignKey("VendedorId");

                    b.HasOne("Biblioteca.Dominio.Categoria", "categoria")
                        .WithMany("productos")
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Publicacion", b =>
                {
                    b.HasOne("Biblioteca.Dominio.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Vendedor", b =>
                {
                    b.HasOne("Biblioteca.Dominio.Tienda", null)
                        .WithMany("Vendedores")
                        .HasForeignKey("TiendaId");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Categoria", b =>
                {
                    b.Navigation("productos");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Tienda", b =>
                {
                    b.Navigation("Productos");

                    b.Navigation("Vendedores");
                });

            modelBuilder.Entity("Biblioteca.Dominio.Vendedor", b =>
                {
                    b.Navigation("productos");
                });
#pragma warning restore 612, 618
        }
    }
}
