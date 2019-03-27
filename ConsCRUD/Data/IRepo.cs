using System;
using System.Collections.Generic;
using System.Linq;
using ConsCRUD.Models;

namespace ConsCRUD.Data
{
    interface IRepo
    {
        Book Create(Book book);
        Book Read(string id);
        List<Book> Read();
        void Update(string id, Book book);
        void Delete(string id);
    }
}
