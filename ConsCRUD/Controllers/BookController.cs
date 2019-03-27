using ConsCRUD.Data;
using ConsCRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsCRUD.Controllers
{
    class BookController
    {
        readonly IRepo _repo;

        public BookController(IRepo repo)
        {
            _repo = repo;
        }

        public void Run()
        {
            while (true)
            {
                Console.Write("C R U D b > ");
                string cmd = Console.ReadLine().ToUpper();
                switch (cmd)
                {
                    case "C":
                        CreateBook();
                        break;
                    case "R":
                        ReadBooks();
                        break;
                    case "U":
                        UpdateBooks();
                        break;
                    case "D":
                        DeleteBooks();
                        break;
                    case "B":
                        return;
                }
            }
        }

        private void CreateBook()
        {
            Console.Write("Book Title > ");
            string title = Console.ReadLine();
            Console.Write("Book Author > ");
            string author = Console.ReadLine();
            Book newBook = new Book { Title = title, Author = author };   
            
            var book = _repo.Create(newBook);

            Console.WriteLine(">>> " + book);
        }

        private void ReadBooks()
        {
            var books = _repo.Read();
            foreach (var book in books)
            {
                Console.WriteLine(">>> " + book);
            }
        }

        private void UpdateBooks()
        {
            Console.Write("Book Id > ");
            int.TryParse(Console.ReadLine(), out int id);

            Book book = _repo.Read(id);
            if (book == null)
            {
                Console.WriteLine("Wrong Book Id.");
                return;
            }
            Console.Write($"Book Title ({book.Title})> ");
            book.Title = Console.ReadLine();
            Console.Write($"Book Author ({book.Author})> ");
            book.Author = Console.ReadLine();

            _repo.Update(id, book);

            Console.WriteLine(">>> " + book);
        }

        private void DeleteBooks()
        {
            Console.Write("Book Id > ");
            int.TryParse(Console.ReadLine(), out int id);

            Book book = _repo.Read(id);
            if (book == null)
            {
                Console.WriteLine("Wrong Book Id.");
                return;
            }
            Console.Write($"Delete {book.Title} ? (Y, N)> ");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                _repo.Delete(id);
                Console.WriteLine("Book was deleted.");
            }
        }

    }
}
