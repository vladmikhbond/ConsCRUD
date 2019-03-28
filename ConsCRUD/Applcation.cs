using ConsCRUD.Controllers;
using ConsCRUD.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace ConsCRUD
{
    class Applcation
    {
        // Infinite loop
        //
        public static void Run()
        {
            // type factory
            IRepo repo = Program.Services.GetRequiredService<IRepo>();
            // for russian letters
            Console.InputEncoding = Console.OutputEncoding = Encoding.GetEncoding("utf-16");
                   
            while (true)
            {
                Console.Write("[B]ooks, [R]eaders, [F]ormulars, [E]xit \n> ");
                string cmd = Console.ReadLine().ToUpper();
                switch (cmd)
                {
                    case "B":
                        new BookController(repo).Run();
                        break;
                    case "R":
                        new ReaderController(repo).Run();
                        break;
                    case "F":
                        break;
                    case "E":
                        return;
                }
            }
        }

    }
}
