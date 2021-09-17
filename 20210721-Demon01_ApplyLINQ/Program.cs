using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplyLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            CaseOne();
            CaseTwo();
            Console.ReadLine();
        }

        //有一个用逗号分隔的表示成绩的字符串，如"61,90,100,
        //99,18,22,38,66,80,93,55,50,89
        //计算这些成绩的平均值
        static void CaseOne()
        {
            string str = "61,90,100,99,18";
            var average = str.Split(',').Average(e => int.Parse(e));
            Console.WriteLine(average);
        }

        //统计一个字符串中每个字母出现的频率（忽略大小写），然后按照从高到低的顺序输出
        //出现频率高于2次的单词和其出现频率
        static void CaseTwo()
        {
            string str = "abcdabcdabcAaBczdhkguiahgadklg";
            var tmp = str.ToUpper().GroupBy(c => c);
            foreach (var value in tmp)
            {
                Console.WriteLine(value.Key);
                Console.WriteLine(value.Count());
                foreach (var value2 in value)
                {
                    Console.WriteLine(value2);
                }
                Console.WriteLine("============");
            }
            Console.WriteLine("xxxxxxxxxxx");
            var word = str.ToUpper().GroupBy(c => c).Select(g => new { DC = g.Key, PL = g.Count() }).
                OrderByDescending(c => c.PL).Where(c => c.PL > 2);
            foreach (var item in word)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
