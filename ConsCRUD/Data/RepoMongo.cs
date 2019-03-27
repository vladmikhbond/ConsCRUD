using System;
using System.Collections.Generic;
using System.Linq;
using ConsCRUD.Models;
using MongoDB.Driver;

namespace ConsCRUD.Data
{
    class RepoMongo: IRepo
    {
        private readonly IMongoCollection<Book> _books;


        public RepoMongo()
        {
            var client = new MongoClient(Program.MongoString);
            var database = client.GetDatabase("BooksDb2");
            _books = database.GetCollection<Book>("Books");
         }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public List<Book> Read()
        {
            return _books.Find(book => true).ToList();
        }


        public Book Read(string id)
        {
            return _books.Find<Book>(book => book.Id == id).FirstOrDefault();
        }

        public void Update(string id, Book book)
        {
            _books.ReplaceOne(b => b.Id == id, book);
        }

        public void Delete(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }
    }
}
