﻿// <auto-generated />
using System;
using ApiGuitarras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiGuitarras.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220918034640_Tiendas")]
    partial class Tiendas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiGuitarras.Entidades.Guitarra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guitarras");
                });

            modelBuilder.Entity("ApiGuitarras.Entidades.Tienda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GuitarraId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuitarraId");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("ApiGuitarras.Entidades.Tienda", b =>
                {
                    b.HasOne("ApiGuitarras.Entidades.Guitarra", "Guitarra")
                        .WithMany("Tiendas")
                        .HasForeignKey("GuitarraId");

                    b.Navigation("Guitarra");
                });

            modelBuilder.Entity("ApiGuitarras.Entidades.Guitarra", b =>
                {
                    b.Navigation("Tiendas");
                });
#pragma warning restore 612, 618
        }
    }
}
