using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ConsEF.Models;
using Microsoft.Extensions.Configuration;

namespace ConsEF.Data
{
    class LibraryContext: DbContext
    {        
        private readonly string _conStr;

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }

        public LibraryContext()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            var conf = builder.Build();
            _conStr = conf["conStr"];
        }

        public LibraryContext(string conStr)
        {
            _conStr = conStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Составной первичный ключ
            modelBuilder.Entity<Record>()
                .HasKey(r => new { r.BookId, r.UserId });

            // Два внешних ключа
            modelBuilder.Entity<Record>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Records)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Record>()
                .HasOne(r => r.User)
                .WithMany(u => u.Records)
                .HasForeignKey(r => r.UserId);

            // Ограничение "NOT NULL" и ограничение длины строки для столбца User.Name
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .IsRequired().HasMaxLength(50);

        }
    }
}
