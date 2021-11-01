using System;
using System.Collections.Generic;

#nullable disable

namespace _211101_Demo01_ScaffoldDbContext
{
    public partial class TBook
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime PubTime { get; set; }
        public double Price { get; set; }
        public string AuthorName { get; set; }
    }
}
