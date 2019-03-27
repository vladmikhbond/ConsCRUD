using System;
using System.Collections.Generic;
using System.Linq;
using ConsCRUD.Models;

namespace ConsCRUD.Data
{
    class RepoMemo: IRepo
    {
        List<Book> _books;

        public RepoMemo()
        {
            _books = new List<Book>();

            // test data
            _books.Add(new Book { Id = "1", Title = "Title1", Author = "Author1" });
            _books.Add(new Book { Id = "2", Title = "Title2", Author = "Author2" });
            _books.Add(new Book { Id = "3", Title = "Title3", Author = "Author3" });
        }

        public Book Create(Book book)
        {
            book.Id = _books.Count == 0 ? "1" : (_books.Max(b => Convert.ToInt32(b.Id)) + 1).ToString();
            _books.Add(book);
            return book;
        }

        public List<Book> Read()
        {
            return _books;
        }


        public Book Read(string id)
        {
            return _books.SingleOrDefault(b => b.Id == id);
        }

        public void Update(string id, Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
