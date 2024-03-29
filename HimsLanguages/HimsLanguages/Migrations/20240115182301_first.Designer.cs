﻿// <auto-generated />
using System;
using HimsLanguages.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HimsLanguages.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240115182301_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HimsLanguages.Data.Entities.Languages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FlagImageFileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LanguageCulture")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Published")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Rtl")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UniqueSeoCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
