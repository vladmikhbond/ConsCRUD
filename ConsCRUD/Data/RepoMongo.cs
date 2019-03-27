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


        public RepoMongo(string conStr)
        {
            var client = new MongoClient(conStr);
            var db = client.GetDatabase("BooksDb2");
            _books = db.GetCollection<Book>("Books");

            // test data
            if (_books.CountDocuments(_ => true) == 0)
            {
                _books.InsertOne(new Book { Title = "Title1", Author = "Author1" });
                _books.InsertOne(new Book { Title = "Title2", Author = "Author2" });
                _books.InsertOne(new Book { Title = "Title3", Author = "Author3" });
            }
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public List<Book> Read()
        {
            return _books.Find(_ => true).ToList();
        }

        public Book Read(string id)
        {
            return _books.Find(b => b.Id == id).FirstOrDefault();
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
