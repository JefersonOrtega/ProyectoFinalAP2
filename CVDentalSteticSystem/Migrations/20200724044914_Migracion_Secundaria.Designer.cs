﻿// <auto-generated />
using System;
using CVDentalSteticSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CVDentalSteticSystem.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200724044914_Migracion_Secundaria")]
    partial class Migracion_Secundaria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("CVDentalSteticSystem.Models.Citas", b =>
                {
                    b.Property<int>("CitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacion")
                        .HasColumnType("TEXT");

                    b.Property<int>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CitaId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("CVDentalSteticSystem.Models.Pacientes", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alergias")
                        .HasColumnType("TEXT");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SeguroMedico")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PacienteId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("CVDentalSteticSystem.Models.Procedimientos", b =>
                {
                    b.Property<int>("ProcedimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EsCobrado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoProcedimientoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProcedimientoId");

                    b.ToTable("Procedimientos");
                });

            modelBuilder.Entity("CVDentalSteticSystem.Models.ProcedimientosDetalles", b =>
                {
                    b.Property<int>("ProcedimientosDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CitaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProcedimeintoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProcedimientoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProcedimientosDetalleId");

                    b.HasIndex("ProcedimeintoId");

                    b.ToTable("ProcedimientosDetalles");
                });

            modelBuilder.Entity("CVDentalSteticSystem.Models.TiposProcedimientos", b =>
                {
                    b.Property<int>("TipoProcedimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreProcedimiento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("TipoProcedimientoId");

                    b.ToTable("TiposProcedimientos");
                });

            modelBuilder.Entity("CVDentalSteticSystem.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("NivelAcceso")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Contrasena = "YQBkAG0AaQBuAA==",
                            Fecha = new DateTime(2020, 7, 24, 0, 49, 13, 949, DateTimeKind.Local).AddTicks(4051),
                            NivelAcceso = "Administrador",
                            Nombres = "admin",
                            Usuario = "admin"
                        });
                });

            modelBuilder.Entity("CVDentalSteticSystem.Models.ProcedimientosDetalles", b =>
                {
                    b.HasOne("CVDentalSteticSystem.Models.Procedimientos", null)
                        .WithMany("ProcedimientoDetalle")
                        .HasForeignKey("ProcedimeintoId");
                });
#pragma warning restore 612, 618
        }
    }
}
