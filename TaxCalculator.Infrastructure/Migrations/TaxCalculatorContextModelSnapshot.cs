﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.Infrastructure.Persistence;

#nullable disable

namespace TaxCalculator.Infrastructure.Migrations
{
    [DbContext(typeof(TaxCalculatorContext))]
    partial class TaxCalculatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaxCalculator.Domain.Entities.CalculatedTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AnnualIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCalculated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CalculatedTax", "dbo");
                });

            modelBuilder.Entity("TaxCalculator.Domain.Entities.ReferenceData.PostalCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("TaxType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PostalCodes", "lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "7441",
                            TaxType = "Progressive"
                        },
                        new
                        {
                            Id = 2,
                            Code = "A100",
                            TaxType = "Flat Value"
                        },
                        new
                        {
                            Id = 3,
                            Code = "7000",
                            TaxType = "Flat Rate"
                        },
                        new
                        {
                            Id = 4,
                            Code = "1000",
                            TaxType = "Progressive"
                        });
                });

            modelBuilder.Entity("TaxCalculator.Domain.Entities.ReferenceData.TaxBaseRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("FromAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<decimal>("ToAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TaxRates", "lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FromAmount = 0m,
                            Rate = 10,
                            ToAmount = 8350m
                        },
                        new
                        {
                            Id = 2,
                            FromAmount = 8351m,
                            Rate = 15,
                            ToAmount = 33950m
                        },
                        new
                        {
                            Id = 3,
                            FromAmount = 33951m,
                            Rate = 25,
                            ToAmount = 82250m
                        },
                        new
                        {
                            Id = 4,
                            FromAmount = 82251m,
                            Rate = 28,
                            ToAmount = 171550m
                        },
                        new
                        {
                            Id = 5,
                            FromAmount = 171551m,
                            Rate = 33,
                            ToAmount = 372950m
                        },
                        new
                        {
                            Id = 6,
                            FromAmount = 372951m,
                            Rate = 35,
                            ToAmount = 0m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
