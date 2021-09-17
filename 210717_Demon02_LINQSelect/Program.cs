using System;
using System.Collections.Generic;
using System.Linq;

namespace _210717_Demon02_LINQSelect
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stuList = new List<Student>()
            {
                new Student(){Age=24,Name="Albert"},
                new Student(){Age=25,Name="Jack",Height=178},
                 new Student(){Age=28,Name="Doris"},
                 new Student(){Age=24,Name="Lucy",Height=176},
                new Student(){Age=25,Name="Boris",Height=180},
                 new Student(){Age=28,Name="Dobin",Height=169}
            };
            var stuSelect = stuList.Where(e=>e.Age>25).Select(e => e.Age+","+e.Height);//将所有的Age取出来
            foreach (var item in stuSelect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("==========");
            var stuSelect2 = stuList.Select(e => e.Age);//将所有的Age取出来
            foreach (var item in stuSelect2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("==========");
            var stuSelect3 = stuList.Select(e => new { Name = "YangZhongKe", Age = 50 });//匿名类型
            foreach (var item in stuSelect3)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("==========");
            //把组里年龄大于26岁,按照年龄分组，并把前两个元素的筛选出来，降序排序，最后打印这些元素的年龄、姓名、身高
            //IGrouping<int,Student>
            var stuSelect4 = stuList.Where(e => e.Age > 26).GroupBy(e => e.Age).Take(1).Select(g => new 
            { Age=g.Key,PJNL=g.Average(e=>e.Age),PJSG=g.Average(e=>e.Height)});
            foreach (var item in stuSelect4)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public double Salary { get; set; }
    }
}
