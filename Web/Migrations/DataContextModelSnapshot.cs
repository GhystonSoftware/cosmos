﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Database;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConstellationLineVisibleStar", b =>
                {
                    b.Property<int>("ConstellationLinesId")
                        .HasColumnType("int");

                    b.Property<int>("StarsId")
                        .HasColumnType("int");

                    b.HasKey("ConstellationLinesId", "StarsId");

                    b.HasIndex("StarsId");

                    b.ToTable("ConstellationLineVisibleStar");
                });

            modelBuilder.Entity("Web.Features.Constellations.Constellation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("StarMapId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StarMapId");

                    b.ToTable("Constellations");
                });

            modelBuilder.Entity("Web.Features.Constellations.ConstellationLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConstellationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConstellationId");

                    b.ToTable("ConstellationLines");
                });

            modelBuilder.Entity("Web.Features.Planets.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DeclinationInDegrees")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<decimal>("DistanceFromEarthInParsecs")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("NumberOfStarsInSystem")
                        .HasColumnType("int");

                    b.Property<decimal>("RelativeBrightnessToSun")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<decimal>("RelativeGravityToEarth")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<decimal>("RelativeMassToEarth")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<decimal>("RelativeSizeToEarth")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<decimal>("RightAscensionInDegrees")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<int>("SunTemperatureInKelvin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("Web.Features.StarMaps.StarMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("StarMaps");
                });

            modelBuilder.Entity("Web.Features.StarMaps.VisibleStar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Brightness")
                        .HasPrecision(3, 3)
                        .HasColumnType("decimal(3,3)");

                    b.Property<int>("StarId")
                        .HasColumnType("int");

                    b.Property<int>("StarMapId")
                        .HasColumnType("int");

                    b.Property<decimal>("X")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("Y")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("StarId");

                    b.HasIndex("StarMapId");

                    b.ToTable("VisibleStars");
                });

            modelBuilder.Entity("Web.Features.Stars.Star", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DeclinationInDegrees")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<decimal>("DistanceFromEarthInParsecs")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<decimal>("Luminosity")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("RightAscensionInDegrees")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.HasKey("Id");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("ConstellationLineVisibleStar", b =>
                {
                    b.HasOne("Web.Features.Constellations.ConstellationLine", null)
                        .WithMany()
                        .HasForeignKey("ConstellationLinesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Web.Features.StarMaps.VisibleStar", null)
                        .WithMany()
                        .HasForeignKey("StarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web.Features.Constellations.Constellation", b =>
                {
                    b.HasOne("Web.Features.StarMaps.StarMap", "StarMap")
                        .WithMany()
                        .HasForeignKey("StarMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StarMap");
                });

            modelBuilder.Entity("Web.Features.Constellations.ConstellationLine", b =>
                {
                    b.HasOne("Web.Features.Constellations.Constellation", null)
                        .WithMany("Lines")
                        .HasForeignKey("ConstellationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web.Features.StarMaps.StarMap", b =>
                {
                    b.HasOne("Web.Features.Planets.Planet", "Planet")
                        .WithMany("StarMaps")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("Web.Features.StarMaps.VisibleStar", b =>
                {
                    b.HasOne("Web.Features.Stars.Star", "Star")
                        .WithMany("VisibleStars")
                        .HasForeignKey("StarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Features.StarMaps.StarMap", "StarMap")
                        .WithMany("VisibleStars")
                        .HasForeignKey("StarMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Star");

                    b.Navigation("StarMap");
                });

            modelBuilder.Entity("Web.Features.Constellations.Constellation", b =>
                {
                    b.Navigation("Lines");
                });

            modelBuilder.Entity("Web.Features.Planets.Planet", b =>
                {
                    b.Navigation("StarMaps");
                });

            modelBuilder.Entity("Web.Features.StarMaps.StarMap", b =>
                {
                    b.Navigation("VisibleStars");
                });

            modelBuilder.Entity("Web.Features.Stars.Star", b =>
                {
                    b.Navigation("VisibleStars");
                });
#pragma warning restore 612, 618
        }
    }
}
