﻿// <auto-generated />
using System;
using Leonardo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Leonardo.Migrations
{
    [DbContext(typeof(FibonacciDataContext))]
    [Migration("20220926132751_AddFibFibonacciCreatedTimestamp")]
    partial class AddFibFibonacciCreatedTimestamp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Leonardo.TFibonacci", b =>
                {
                    b.Property<Guid>("FibId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FIB_Id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("FibCreatedTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("FIB_CreatedTimestamp")
                        .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                    b.Property<int>("FibInput")
                        .HasColumnType("int")
                        .HasColumnName("FIB_Input");

                    b.Property<long>("FibOutput")
                        .HasColumnType("bigint")
                        .HasColumnName("FIB_Output");

                    b.HasKey("FibId")
                        .HasName("PK_Fibonacci");

                    b.ToTable("T_Fibonacci", "sch_fib");
                });
#pragma warning restore 612, 618
        }
    }
}