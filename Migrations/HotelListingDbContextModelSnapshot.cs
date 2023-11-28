﻿// <auto-generated />
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelListing.API.Migrations
{
    [DbContext(typeof(HotelListingDbContext))]
    partial class HotelListingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelListing.API.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Great Britain",
                            ShortName = "GB"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Belarus",
                            ShortName = "BY"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Poland",
                            ShortName = "PL"
                        },
                        new
                        {
                            Id = 4,
                            Name = "United States",
                            ShortName = "US"
                        });
                });

            modelBuilder.Entity("HotelListing.API.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "London",
                            CountryId = 1,
                            Name = "Royal Palace",
                            Rating = 4.9900000000000002
                        },
                        new
                        {
                            Id = 2,
                            Address = "Glasgow",
                            CountryId = 1,
                            Name = "Scottish Adventure Resort",
                            Rating = 4.8499999999999996
                        },
                        new
                        {
                            Id = 3,
                            Address = "Minsk",
                            CountryId = 2,
                            Name = "Gastinitza Tourist",
                            Rating = 4.6500000000000004
                        },
                        new
                        {
                            Id = 4,
                            Address = "Cherven",
                            CountryId = 2,
                            Name = "Village hills appointment",
                            Rating = 4.3399999999999999
                        },
                        new
                        {
                            Id = 5,
                            Address = "Warshaw",
                            CountryId = 3,
                            Name = "Kurva collection resort",
                            Rating = 4.8499999999999996
                        },
                        new
                        {
                            Id = 6,
                            Address = "Los-Angeles",
                            CountryId = 4,
                            Name = "LA sand beach",
                            Rating = 4.5499999999999998
                        },
                        new
                        {
                            Id = 7,
                            Address = "Seattle",
                            CountryId = 4,
                            Name = "Sunset sight",
                            Rating = 4.8499999999999996
                        });
                });

            modelBuilder.Entity("HotelListing.API.Data.Hotel", b =>
                {
                    b.HasOne("HotelListing.API.Data.Country", "Country")
                        .WithMany("Hotels")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HotelListing.API.Data.Country", b =>
                {
                    b.Navigation("Hotels");
                });
#pragma warning restore 612, 618
        }
    }
}