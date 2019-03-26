using System;
using System.Collections.Generic;
using System.Text;

namespace ConsCRUD
{
    class Applcation
    {
        public static void Run()
        {
            while (true) {
                Console.Write("CRUD > ");
                string cmd = Console.ReadLine().ToUpper();
                switch (cmd) {
                    case "C":
                        CreateBook();
                        break;
                    case "R":
                        ReadBooks();
                        break;
                    case "U":
                        break;
                    case "D":
                        break;
                    case "B":
                        return;
                }
            }
        }

        private static void CreateBook()
        {
            Console.Write("Book Title> ");
            string title = Console.ReadLine();
            Console.Write("Book Author> ");
            string author = Console.ReadLine();
            Book newBook = new Book { Title = title, Author = author };

            IRepo repo = new RepoM();
            var book = repo.Create(newBook);

            Console.WriteLine(">>> " + book);
        }

        private static void ReadBooks()
        {
            IRepo repo = new RepoM();
            var books = repo.Read();

            Console.WriteLine(">>> " + books);
        }

    }
}
