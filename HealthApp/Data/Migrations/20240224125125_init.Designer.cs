﻿// <auto-generated />
using System;
using HealthApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240224125125_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthApp.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("YourProject.Models.PatientRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ALT")
                        .HasColumnType("int");

                    b.Property<string>("ANA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AST")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AntiCCP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntiDsDNA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Autoantibodies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodPressure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("BodyTemperature")
                        .HasColumnType("real");

                    b.Property<string>("CPeptide")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CRP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Cholesterol")
                        .HasColumnType("int");

                    b.Property<string>("Creatinine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentMedications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ESR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EchocardiogramResults")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FEV1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FEV1FVCRatio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FVC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FastingGlucose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalDiagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GFR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HbA1c")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HeartRate")
                        .HasColumnType("int");

                    b.Property<string>("Hemoglobin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MRIFindings")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OxygenSaturation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platelets")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RBC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RespiratoryRate")
                        .HasColumnType("int");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SystemicManifestations")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WBC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XRayFindings")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
