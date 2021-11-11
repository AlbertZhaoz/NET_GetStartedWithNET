using System;
using System.Collections.Generic;

#nullable disable

namespace _211101_Demo01_ScaffoldDbContext
{
    public partial class TPerson
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BirthPlace { get; set; }
        public double? Salary { get; set; }
        //?表示可空类型
        public DateTime? BirthDay { get; set; }
    }
}
