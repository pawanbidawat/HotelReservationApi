﻿// <auto-generated />
using System;
using HotelApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240318072048_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelApi.Models.DTO.BlackoutDateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("BlackoutDate");
                });

            modelBuilder.Entity("HotelApi.Models.DTO.HotelDetailsModel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<string>("BlockedChildRange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HotelId");

                    b.ToTable("HotelDetails");
                });

            modelBuilder.Entity("HotelApi.Models.DTO.HotelRoomModel", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<decimal>("AdultRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ChildRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DoubleRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("ExceptionCase")
                        .HasColumnType("bit");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("NoChild")
                        .HasColumnType("bit");

                    b.Property<bool>("NoExtraAdult")
                        .HasColumnType("bit");

                    b.Property<string>("RoomImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SingleEqualDouble")
                        .HasColumnType("bit");

                    b.Property<decimal>("SingleRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TripleRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("HotelApi.Models.DTO.BlackoutDateModel", b =>
                {
                    b.HasOne("HotelApi.Models.DTO.HotelRoomModel", "RoomModel")
                        .WithMany("BlackoutDates")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomModel");
                });

            modelBuilder.Entity("HotelApi.Models.DTO.HotelRoomModel", b =>
                {
                    b.HasOne("HotelApi.Models.DTO.HotelDetailsModel", "Hotel")
                        .WithMany("RoomDetails")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelApi.Models.DTO.HotelDetailsModel", b =>
                {
                    b.Navigation("RoomDetails");
                });

            modelBuilder.Entity("HotelApi.Models.DTO.HotelRoomModel", b =>
                {
                    b.Navigation("BlackoutDates");
                });
#pragma warning restore 612, 618
        }
    }
}
