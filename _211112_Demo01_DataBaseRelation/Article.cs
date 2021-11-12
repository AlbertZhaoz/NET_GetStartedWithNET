using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211112_Demo01_DataBaseRelation
{
    public class Article
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
