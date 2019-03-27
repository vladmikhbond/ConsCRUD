using System;
using System.Collections.Generic;
using System.Linq;
using ConsCRUD.Models;

namespace ConsCRUD.Data
{
    interface IRepo
    {
        Book Create(Book book);
        Book Read(int id);
        List<Book> Read();
        void Update(int id, Book book);
        void Delete(int id);
    }

    class RepoM: IRepo
    {
        List<Book> _books;

        public RepoM()
        {
            _books = new List<Book>();

            // test data
            _books.Add(new Book { Id = 1, Title = "Title1", Author = "Author1" });
            _books.Add(new Book { Id = 2, Title = "Title2", Author = "Author2" });
            _books.Add(new Book { Id = 3, Title = "Title3", Author = "Author3" });
        }

        public Book Create(Book book)
        {
            book.Id = _books.Count == 0 ? 1 : _books.Max(b => b.Id) + 1;
            _books.Add(book);
            return book;
        }

        public List<Book> Read()
        {
            return _books;
        }


        public Book Read(int id)
        {
            return _books.SingleOrDefault(b => b.Id == id);
        }

        public void Update(int id, Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
