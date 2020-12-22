﻿// <auto-generated />
using System;
using CCM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CCM.Domain.Migrations
{
    [DbContext(typeof(ccmContext))]
    partial class ccmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CCM.Domain.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("day");
                });

            modelBuilder.Entity("CCM.Domain.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("AuthorizedCapacity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'100'");

                    b.Property<int>("Capacity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("ImagePath")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(200)")
                        .HasDefaultValueSql("'NULL'")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'NULL'");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId")
                        .HasName("map_organisation_Id_fk");

                    b.ToTable("map");
                });

            modelBuilder.Entity("CCM.Domain.Openingtime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClosingHour")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("OpeningHour")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DayId")
                        .HasName("openingtime_day_Id_fk");

                    b.HasIndex("MapId")
                        .HasName("openingtime_map_Id_fk");

                    b.ToTable("openingtime");
                });

            modelBuilder.Entity("CCM.Domain.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("organisation");
                });

            modelBuilder.Entity("CCM.Domain.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("EndHour")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasDefaultValueSql("'NULL'")
                        .HasMaxLength(100);

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("StartHour")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasDefaultValueSql("'NULL'")
                        .HasMaxLength(100);

                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'NULL'");
                    
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(250)")
                        .HasDefaultValueSql("'NULL'");

                    b.HasKey("Id");

                    b.HasIndex("SeatId")
                        .HasName("reservation_seat_Id_fk");

                    b.HasIndex("UserId")
                        .HasName("reservation_user_Id_fk");

                    b.ToTable("reservation");
                });

            modelBuilder.Entity("CCM.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("CCM.Domain.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int>("X")
                        .HasColumnName("x")
                        .HasColumnType("int(11)");

                    b.Property<int>("Y")
                        .HasColumnName("y")
                        .HasColumnType("int(11)");
                   
                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("MapId")
                        .HasName("seat_map_Id_fk");

                    b.ToTable("seat");
                });

            modelBuilder.Entity("CCM.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(150)")
                        .HasDefaultValueSql("'NULL'")
                        .HasMaxLength(150);

                    b.Property<string>("FirstName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("'NULL'")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("'NULL'")
                        .HasMaxLength(50);

                    b.Property<int>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Password")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(150)")
                        .HasDefaultValueSql("'NULL'")
                        .HasMaxLength(150);

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'NULL'");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId")
                        .HasName("user_organisation_Id_fk");

                    b.HasIndex("RoleId")
                        .HasName("user_role_Id_fk");

                    b.ToTable("user");
                });

            modelBuilder.Entity("CCM.Domain.Map", b =>
                {
                    b.HasOne("CCM.Domain.Organisation", "Organisation")
                        .WithMany("Map")
                        .HasForeignKey("OrganisationId")
                        .HasConstraintName("map_organisation_Id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CCM.Domain.Openingtime", b =>
                {
                    b.HasOne("CCM.Domain.Day", "Day")
                        .WithMany("Openingtime")
                        .HasForeignKey("DayId")
                        .HasConstraintName("openingtime_day_Id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CCM.Domain.Map", "Map")
                        .WithMany("Openingtime")
                        .HasForeignKey("MapId")
                        .HasConstraintName("openingtime_map_Id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CCM.Domain.Reservation", b =>
                {
                    b.HasOne("CCM.Domain.Seat", "Seat")
                        .WithMany("Reservation")
                        .HasForeignKey("SeatId")
                        .HasConstraintName("reservation_seat_Id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CCM.Domain.User", "User")
                        .WithMany("Reservation")
                        .HasForeignKey("UserId")
                        .HasConstraintName("reservation_user_Id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CCM.Domain.Seat", b =>
                {
                    b.HasOne("CCM.Domain.Map", "Map")
                        .WithMany("Seat")
                        .HasForeignKey("MapId")
                        .HasConstraintName("seat_map_Id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CCM.Domain.User", b =>
                {
                    b.HasOne("CCM.Domain.Organisation", "Organisation")
                        .WithMany("User")
                        .HasForeignKey("OrganisationId")
                        .HasConstraintName("user_organisation_Id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CCM.Domain.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("user_role_Id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
