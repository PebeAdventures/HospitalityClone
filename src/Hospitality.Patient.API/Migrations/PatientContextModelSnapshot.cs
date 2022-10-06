﻿// <auto-generated />
using System;
using Hospitality.Patient.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospitality.Patient.API.Migrations
{
    [DbContext(typeof(PatientContext))]
    partial class PatientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hospitality.Patient.API.Data.HospitalPatient", b =>
                {
                    b.Property<int>("HospitalPatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalPatientId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInsured")
                        .HasColumnType("bit");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientPesel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalPatientId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            HospitalPatientId = 1,
                            Address = "Wrzosowa",
                            BirthDate = new DateTime(1999, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "aniela.nowak@proton.me",
                            IsInsured = true,
                            PatientName = "Aniela",
                            PatientPesel = "99112234543",
                            PatientSurname = "Nowak",
                            PhoneNumber = "213769420"
                        },
                        new
                        {
                            HospitalPatientId = 2,
                            Address = "Jaworowa",
                            BirthDate = new DateTime(1998, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ania.okrasa@proton.me",
                            IsInsured = true,
                            PatientName = "Ania",
                            PatientPesel = "98112234543",
                            PatientSurname = "Okrasa",
                            PhoneNumber = "123456456"
                        },
                        new
                        {
                            HospitalPatientId = 3,
                            Address = "Fiołkowa",
                            BirthDate = new DateTime(1997, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michal.jakos@proton.me",
                            IsInsured = true,
                            PatientName = "Michał",
                            PatientPesel = "97112234543",
                            PatientSurname = "Jakos",
                            PhoneNumber = "456789123"
                        },
                        new
                        {
                            HospitalPatientId = 4,
                            Address = "Jaworowa",
                            BirthDate = new DateTime(1998, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michal.jakos@proton.me",
                            IsInsured = false,
                            PatientName = "Olaf",
                            PatientPesel = "98122255543",
                            PatientSurname = "Olal",
                            PhoneNumber = "999456456"
                        },
                        new
                        {
                            HospitalPatientId = 5,
                            Address = "Fiołkowa",
                            BirthDate = new DateTime(1997, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ania.okrasa@proton.me",
                            IsInsured = true,
                            PatientName = "Dawid",
                            PatientPesel = "97102233343",
                            PatientSurname = "Jac",
                            PhoneNumber = "458889123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
