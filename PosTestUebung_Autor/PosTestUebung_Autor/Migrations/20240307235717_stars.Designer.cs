﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PosTestUebung_Autor.Data;

#nullable disable

namespace PosTestUebung_Autor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240307235717_stars")]
    partial class stars
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("PosTestUebung_Autor.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Autoren");
                });

            modelBuilder.Entity("PosTestUebung_Autor.Models.Buch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AutorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Pagecount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stars")
                        .HasMaxLength(5)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Buecher");
                });

            modelBuilder.Entity("PosTestUebung_Autor.Models.Buch", b =>
                {
                    b.HasOne("PosTestUebung_Autor.Models.Autor", "Autor")
                        .WithMany("Buecher")
                        .HasForeignKey("AutorId");

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("PosTestUebung_Autor.Models.Autor", b =>
                {
                    b.Navigation("Buecher");
                });
#pragma warning restore 612, 618
        }
    }
}