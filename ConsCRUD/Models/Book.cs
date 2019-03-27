using System;
using System.Collections.Generic;
using System.Text;

namespace ConsCRUD.Models
{
    class Book
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Author { set; get; }

        public override string ToString() => 
            $"Id={Id}  Title='{Title}'  Author='{Author}'";
    }
}
