using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210917_Demon01_EFCoreAlbert
{
    [Table("T_Cats")]
    public class Cat
    {
        public long Id { get; set; }//主键
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }//名字
    }
}
