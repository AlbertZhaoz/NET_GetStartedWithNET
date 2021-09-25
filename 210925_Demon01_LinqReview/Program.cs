using System;
using System.Collections.Generic;
using System.Linq;

namespace _210925_Demon01_LinqReview
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 2, 3, 54, 643, 63, 7, 78 };         
            var tmp = nums.AlbertWhere(a => a > 10);
            foreach (var item in tmp)
            {
                Console.WriteLine(item);
            }
            
        }       
    }
}
