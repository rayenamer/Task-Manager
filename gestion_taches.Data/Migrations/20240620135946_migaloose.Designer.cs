﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gestion_taches.Data.Context;

#nullable disable

namespace gestion_taches.Data.Migrations
{
    [DbContext(typeof(gestionTachesContext))]
    [Migration("20240620135946_migaloose")]
    partial class migaloose
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gestion_taches.Domain.models.Project", b =>
                {
                    b.Property<Guid>("IdProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("BudgetAllouee")
                        .HasColumnType("real");

                    b.Property<DateOnly>("DateDebut")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinPrevue")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nomp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priorité")
                        .HasColumnType("int");

                    b.HasKey("IdProject");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("gestion_taches.Domain.models.Ressources", b =>
                {
                    b.Property<Guid>("IdRessources")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Cout")
                        .HasColumnType("real");

                    b.Property<string>("Etat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdProject")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRessources");

                    b.HasIndex("IdProject");

                    b.ToTable("Ressources");
                });

            modelBuilder.Entity("gestion_taches.Domain.models.Ressources", b =>
                {
                    b.HasOne("gestion_taches.Domain.models.Project", "Project")
                        .WithMany("Ressources")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("gestion_taches.Domain.models.Project", b =>
                {
                    b.Navigation("Ressources");
                });
#pragma warning restore 612, 618
        }
    }
}
