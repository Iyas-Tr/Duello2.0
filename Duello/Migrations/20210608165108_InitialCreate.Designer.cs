﻿// <auto-generated />
using System;
using Duello.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Duello.Migrations
{
    [DbContext(typeof(BudgetDatabase))]
    [Migration("20210608165108_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Duello.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("JumlahUang")
                        .HasColumnType("float");

                    b.Property<string>("NamaBudget")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Budgetss");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Budget");
                });

            modelBuilder.Entity("Duello.Expense", b =>
                {
                    b.HasBaseType("Duello.Budget");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Expense");
                });

            modelBuilder.Entity("Duello.Income", b =>
                {
                    b.HasBaseType("Duello.Budget");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2")
                        .HasColumnName("Income_Tanggal");

                    b.HasDiscriminator().HasValue("Income");
                });
#pragma warning restore 612, 618
        }
    }
}
