using System;
using System.Collections.Generic;
using System.Text;

namespace ConsEF.Models
{
    class Record
    {
        public int BookId { set; get; }
        public int UserId { set; get; }
        public DateTime When { set; get; }
        //
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
