using ConsCRUD.Controllers;
using ConsCRUD.Data;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsCRUD
{
    class Applcation
    {
        // Infinite loop
        //
        public static void Run()
        {
            IRepo repo = Program.Services.GetRequiredService<IRepo>();

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
                        new BookController(repo).Run();
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
