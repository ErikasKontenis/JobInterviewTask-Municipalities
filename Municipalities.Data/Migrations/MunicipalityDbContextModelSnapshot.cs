﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Municipalities.Data.DbContexts;
using System;

namespace Municipalities.Data.Migrations
{
    [DbContext(typeof(MunicipalityDbContext))]
    partial class MunicipalityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Municipalities.Domain.Municipalities.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("Municipalities.Domain.Municipalities.MunicipalityTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("MunicipalityId");

                    b.Property<DateTime>("StartDate");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("MunicipalityTaxes");
                });

            modelBuilder.Entity("Municipalities.Domain.Municipalities.MunicipalityTax", b =>
                {
                    b.HasOne("Municipalities.Domain.Municipalities.Municipality", "Municipality")
                        .WithMany("MunicipalityTaxes")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}