using System;
using System.Collections.Generic;
using System.Text;

namespace ConsCRUD
{
    interface IRepo
    {
        Book Create(Book book);
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
            // todo: test data
        }

        public Book Create(Book book)
        {
            book.Id = 0;  // todo: get id
            return book;
        }

        public List<Book> Read()
        {
            return _books;
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
