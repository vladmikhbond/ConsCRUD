using ConsCRUD.Data;
using ConsCRUD.Models;
using System;

namespace ConsCRUD.Controllers
{
    class BookController
    {
        readonly IRepo _repo;

        public BookController(IRepo repo)
        {
            _repo = repo;
        }

        // controller loop
        //
        public void Run()
        {
            while (true)
            {
                Console.Write("C R U D E > ");
                string cmd = Console.ReadLine().ToUpper();
                switch (cmd)
                {
                    case "C":
                        Create();
                        break;
                    case "R":
                        Read();
                        break;
                    case "U":
                        Update();
                        break;
                    case "D":
                        Delete();
                        break;
                    case "E":
                        return;
                }
            }
        }

        private void Create()
        {
            // get params
            Console.Write("Book Title > ");
            string title = Console.ReadLine();
            Console.Write("Book Author > ");
            string author = Console.ReadLine();
            Book newBook = new Book { Title = title, Author = author };   
            // do operation
            var book = _repo.Create(newBook);
            // show result
            Console.WriteLine(">>> " + book);
        }

        private void Read()
        {
            // do operation
            var books = _repo.Read();
            // show result
            foreach (var book in books)
            {
                Console.WriteLine(">>> " + book);
            }
        }

        private void Update()
        {
            // get params
            Console.Write("Book Id > ");
            string id = Console.ReadLine();

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

            // do operation
            _repo.Update(id, book);
            // show result
            Console.WriteLine(">>> " + book);
        }

        private void Delete()
        {
            // get params
            Console.Write("Book Id > ");
            string id = Console.ReadLine();

            Book book = _repo.Read(id);
            if (book == null)
            {
                Console.WriteLine("Wrong Book Id.");
                return;
            }
            // confirmation
            Console.Write($"Delete {book.Title} ? (Y, N)> ");
            string answer = Console.ReadLine().ToUpper();
            if (answer != "Y")
                return;
            
            // do operation
            _repo.Delete(id);
            // show result
            Console.WriteLine("Book was deleted.");
            
        }

    }
}
