using System;
using System.Collections.Generic;

namespace BookApiCore1.Models
{
    public partial class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}
