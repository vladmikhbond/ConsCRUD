using System.Collections.Generic;

namespace ConsEF.Models
{
    class Book
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Author { set; get; }
        //
        public ICollection<Record> Records { set; get; }
    }
}
