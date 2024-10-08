﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WeatherRepository.Models;

#nullable disable

namespace WeatherRepository.Migrations
{
    [DbContext(typeof(WeatherExampleDbContext))]
    [Migration("20240912183534_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WeatherRepository.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("region_pkey");

                    b.ToTable("region", (string)null);
                });

            modelBuilder.Entity("WeatherRepository.Models.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("RegionId")
                        .HasColumnType("integer")
                        .HasColumnName("region_id");

                    b.Property<double?>("Temperature")
                        .HasColumnType("double precision")
                        .HasColumnName("temperature");

                    b.HasKey("Id")
                        .HasName("weather_pkey");

                    b.HasIndex("RegionId");

                    b.ToTable("weather", (string)null);
                });

            modelBuilder.Entity("WeatherRepository.Models.Weather", b =>
                {
                    b.HasOne("WeatherRepository.Models.Region", "Region")
                        .WithMany("Weathers")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("weather_region_id_fkey");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("WeatherRepository.Models.Region", b =>
                {
                    b.Navigation("Weathers");
                });
#pragma warning restore 612, 618
        }
    }
}
