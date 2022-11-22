﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectoEF.Contexto;

#nullable disable

namespace Proyecto.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20221122173815_modificandoDatos1")]
    partial class modificandoDatos1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("proyectoEF.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaID");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaID = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                            Nombre = "Actividades pendientesEdit",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaID = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                            Nombre = "Actividades personalesEdit",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("proyectoEF.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaID");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                            CategoriaID = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                            FechaCreacion = new DateTime(2022, 11, 22, 11, 38, 15, 816, DateTimeKind.Local).AddTicks(2511),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios publicosEdit"
                        },
                        new
                        {
                            TareaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                            CategoriaID = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                            FechaCreacion = new DateTime(2022, 11, 22, 11, 38, 15, 816, DateTimeKind.Local).AddTicks(2526),
                            PrioridadTarea = 0,
                            Titulo = "Terminar de ver pelicula en netflixEdit"
                        });
                });

            modelBuilder.Entity("proyectoEF.Models.Tarea", b =>
                {
                    b.HasOne("proyectoEF.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proyectoEF.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}