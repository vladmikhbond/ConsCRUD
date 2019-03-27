using ConsCRUD.Data;
using ConsCRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsCRUD.Controllers
{
    class ReaderController
    {
        readonly IRepo _repo;

        public ReaderController(IRepo repo)
        {
            _repo = repo;
        }

        public void Run()
        {
        }

    }
}
