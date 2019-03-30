using System.Collections.Generic;

namespace ConsEF.Models
{
    class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        //
        public ICollection<Record> Records { set; get; }
    }
}
