﻿// <auto-generated />
using System;
using Jopp_lunch.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jopp_lunch.Migrations
{
    [DbContext(typeof(CanteenContext))]
    [Migration("20240417172859_AddDefaultVM")]
    partial class AddDefaultVM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jopp_lunch.Model.DbEntities.Canteen", b =>
                {
                    b.Property<int>("cislo_VM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cislo_VM"));

                    b.Property<string>("nazev")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cislo_VM");

                    b.ToTable("vyjedni_mista", (string)null);
                });

            modelBuilder.Entity("Jopp_lunch.Model.DbEntities.Choice", b =>
                {
                    b.Property<int>("cislo_vyberu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cislo_vyberu"));

                    b.Property<string>("cislo_uzivateleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("forma")
                        .HasColumnType("int");

                    b.Property<int>("obedIdcislo_obeda")
                        .HasColumnType("int");

                    b.Property<int>("pocet")
                        .HasColumnType("int");

                    b.Property<int>("vydejni_mistocislo_VM")
                        .HasColumnType("int");

                    b.HasKey("cislo_vyberu");

                    b.HasIndex("cislo_uzivateleId");

                    b.HasIndex("obedIdcislo_obeda");

                    b.HasIndex("vydejni_mistocislo_VM");

                    b.ToTable("vybery", (string)null);
                });

            modelBuilder.Entity("Jopp_lunch.Model.DbEntities.Lunch", b =>
                {
                    b.Property<int>("cislo_obeda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cislo_obeda"));

                    b.Property<int>("cislo_polevkypolevkaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum_editace")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datum_pridani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datum_vydeje")
                        .HasColumnType("datetime2");

                    b.Property<string>("popis_obeda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cislo_obeda");

                    b.HasIndex("cislo_polevkypolevkaId");

                    b.ToTable("obedy", (string)null);
                });

            modelBuilder.Entity("Jopp_lunch.Model.DbEntities.Soup", b =>
                {
                    b.Property<int>("polevkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("polevkaId"));

                    b.Property<DateTime>("datum_editace")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datum_pridani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datum_vydeje")
                        .HasColumnType("datetime2");

                    b.Property<string>("popis_obeda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("polevkaId");

                    b.ToTable("polevky", (string)null);
                });

            modelBuilder.Entity("Jopp_lunch.Model.DbEntities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("jmeno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("osobni_cislo")
                        .HasColumnType("int");

                    b.Property<string>("prijmeni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("vychozi_VMcislo_VM")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("vychozi_VMcislo_VM");

                    b.ToTable("uzivatele", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d57b7c9f-8fbb-4f81-92a7-4bf27b2833fa",
                            Name = "admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "dd2b152c-297b-4e2a-8f2c-f5df1b7688f5",
                            Name = "editor",
                            NormalizedName = "editor"
                        },
                        new
                        {
                            Id = "d9415606-d4ee-4a0c-af5a-c512b88e2ab6",
                            Name = "chef",
                            NormalizedName = "chef"
                        },
                        new
                        {
                            Id = "4f3290a0-89e7-498b-8a8f-3e74e238c39e",
                            Name = "employee",
                            NormalizedName = "employee"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Jopp_lunch.Model.DbEntities.Choice", b =>
                {
                    b.HasOne("Jopp_lunch.Model.DbEntities.User", "cislo_uzivatele")
                        .WithMany()
                        .HasForeignKey("cislo_uzivateleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jopp_lunch.Model.DbEntities.Lunch", "obedId")
                        .WithMany()
                        .HasForeignKey("obedIdcislo_obeda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jopp_lunch.Model.DbEntities.Canteen", "vydejni_misto")
                        .WithMany()
                        .HasForeignKey("vydejni_mistocislo_VM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cislo_uzivatele");

                    b.Navigation("obedId");

                    b.Navigation("vydejni_misto");
                });

            modelBuilder.Entity("Jopp_lunch.Model.DbEntities.Lunch", b =>
                {
                    b.HasOne("Jopp_lunch.Model.DbEntities.Soup", "cislo_polevky")
                        .WithMany()
                        .HasForeignKey("cislo_polevkypolevkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cislo_polevky");
                });

            modelBuilder.Entity("Jopp_lunch.Model.DbEntities.User", b =>
                {
                    b.HasOne("Jopp_lunch.Model.DbEntities.Canteen", "vychozi_VM")
                        .WithMany()
                        .HasForeignKey("vychozi_VMcislo_VM");

                    b.Navigation("vychozi_VM");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Jopp_lunch.Model.DbEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Jopp_lunch.Model.DbEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jopp_lunch.Model.DbEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Jopp_lunch.Model.DbEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}