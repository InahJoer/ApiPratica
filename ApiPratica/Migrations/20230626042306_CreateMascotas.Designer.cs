﻿// <auto-generated />
using System;
using ApiPratica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPratica.Migrations
{
    [DbContext(typeof(ApiPraticaContext))]
    [Migration("20230626042306_CreateMascotas")]
    partial class CreateMascotas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiPratica.Models.Mascotas", b =>
                {
                    b.Property<int>("MascotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MascotaId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("MascotaDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MascotaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RazaId")
                        .HasColumnType("int");

                    b.HasKey("MascotaId");

                    b.HasIndex("RazaId");

                    b.ToTable("Mascotas");

                    b.HasData(
                        new
                        {
                            MascotaId = 1,
                            Fecha = new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MascotaDescription = "Pequeño",
                            MascotaName = "Juan",
                            RazaId = 1
                        },
                        new
                        {
                            MascotaId = 2,
                            Fecha = new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MascotaDescription = "Gorda",
                            MascotaName = "Oswaldo",
                            RazaId = 2
                        });
                });

            modelBuilder.Entity("ApiPratica.Models.Raza", b =>
                {
                    b.Property<int>("RazaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RazaId"));

                    b.Property<string>("RazaColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RazaId");

                    b.ToTable("Raza");

                    b.HasData(
                        new
                        {
                            RazaId = 1,
                            RazaColor = "Negrote",
                            RazaName = "Chihuahua"
                        },
                        new
                        {
                            RazaId = 2,
                            RazaColor = "Verde",
                            RazaName = "Pitbull"
                        });
                });

            modelBuilder.Entity("ApiPratica.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contraseña = "holaquepasa",
                            NombreUsuario = "Chejudos",
                            Rol = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Contraseña = "megustanmenores",
                            NombreUsuario = "Mrpimiento",
                            Rol = "Vendedor"
                        });
                });

            modelBuilder.Entity("ApiPratica.Models.Mascotas", b =>
                {
                    b.HasOne("ApiPratica.Models.Raza", "Raza")
                        .WithMany()
                        .HasForeignKey("RazaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Raza");
                });
#pragma warning restore 612, 618
        }
    }
}