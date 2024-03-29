﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using HimsLanguages.Data.Entities;
using System.Diagnostics.Metrics;
using System;

namespace HimsLanguages.Data
{
    public class Context : DbContext
    {

        public Context() : base() { }
        public DbSet<Languages> Languages { get; set;}//auther

        public DbSet<LocaleStringResources> LocaleStringResource { get; set; }
        public Context(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server = localhost; Database = LanguagesModel; User = root; Password = Hiba@123");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Author and Book
            modelBuilder.Entity<Languages>()
            .HasMany(alt => alt.LocaleStringResource)
            .WithOne().HasForeignKey(k => k.LanguagesId);


          


        }



    }
}