using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211112_Demo01_DataBaseRelation
{
    public class Comment
    {
        public long ID { get; set; }
        public Article Article { get; set; }

    }
}
