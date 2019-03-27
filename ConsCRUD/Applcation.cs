using ConsCRUD.Controllers;
using ConsCRUD.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsCRUD
{
    class Applcation
    {
        // Infinite loop
        //
        public static void Run()
        {
            while (true)
            {
                Console.Write("[B]ooks, [R]eaders, [F]ormulars, [E]xit \n> ");
                string cmd = Console.ReadLine().ToUpper();
                switch (cmd)
                {
                    case "B":
                        new BookController(new RepoM()).Run();
                        break;
                    case "R":
                        new BookController(new RepoM()).Run();
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
