using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _20210713_Demo02_LIQNImprotant
{
    delegate void TestDelegate();
    static class Program
    {       
        static void Main(string[] args)
        {
            string s = "adbdfaghagkaewqrwosfbafaof1214afhkaf";
            var items = s.Where(c => char.IsLetter(c))//过滤非字母
                .Select(c => char.ToUpper(c))//全部转换为大写
                .GroupBy(c => c)//根据字母进行分组 这里变成了类似字典的东西
                .Where(g => g.Count() > 2)//过滤掉出现次数<=2的字符
                .OrderByDescending(g => g.Count())//按次序降序排序
                .Select(g => new { Char = g.Key, Count = g.Count() });
            foreach (var item in items)
            {
                Console.WriteLine(item.Char);
                Console.WriteLine(item.Count);
            }

            //委托是一个类型，需要创建实例，同步调用、异步调用（容易造成资源竞争）
            TestDelegate testDelegate = new TestDelegate(F1);
            testDelegate = F1;//这样直接赋值也可以，委托testDelegate指向F1方法，方法的指针，方法模板。
            testDelegate.Invoke();

            Func<int, int, string> func = (a, b) => { return $"{a + b}"; };
            Console.WriteLine(func(1,2));

            int[] nums = new int[] { 1, 2, 3, 54, 643, 63, 7, 78 };
            var tmp = nums.Where(i => i > 10);
            foreach (var temp1 in tmp)
            {
                Console.WriteLine(temp1);
            }

            tmp = MyWhere(nums,i => i > 10);
            foreach (var temp1 in tmp)
            {
                Console.WriteLine(temp1);
            }

            tmp = nums.MyWhereKuo(a => a > 10);
            foreach (var temp1 in tmp)
            {
                Console.WriteLine(temp1);
            }
        }

        public static IEnumerable<int> MyWhereKuo(this IEnumerable<int> items,Func<int,bool> func)
        {
            foreach (var item in items)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }

        static IEnumerable<int> MyWhere(IEnumerable<int> items,Func<int,bool> func)
        {
            foreach (var item in items)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }


        static void F1()
        {
            Console.WriteLine("我是F1");
        }


    }
}
