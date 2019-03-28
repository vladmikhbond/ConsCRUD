using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ConsCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsCRUD.Data
{
    class RepoEF: DbContext, IRepo
    {        
        readonly string _conStr;

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conStr);
        }

        public RepoEF(string conStr)
        {
            _conStr = conStr;
        }

        public Book Create(Book book)
        {
            book.Id = Guid.NewGuid().ToString();
            Books.Add(book);
            SaveChanges();
            return book;
        }

        public List<Book> Read() => 
            Books.ToList();       

        public Book Read(string id) =>
            Books.Find(id);
        

        public void Update(string id, Book book)
        {
            var bookToUpdate = Books.Find(id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                SaveChanges();
            }
        }

        public void Delete(string id)
        {
            var bookToDelete = Books.Find(id);
            if (bookToDelete != null)
            {
                Books.Remove(bookToDelete);
                SaveChanges();
            }
        }

    }
}
