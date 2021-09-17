using System;
using System.Collections.Generic;
using System.Linq;

namespace _210717_Demon01_LINQExpand
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stuList = new List<Student>()
            {
                new Student(){Age=24,Name="Albert",Height=176},
                new Student(){Age=25,Name="Jack",Height=178},
                 new Student(){Age=28,Name="Doris",Height=165},
                 new Student(){Age=24,Name="Lucy",Height=176},
                new Student(){Age=25,Name="Boris",Height=180},
                 new Student(){Age=28,Name="Dobin",Height=169}
            };

            var groupStu = stuList.GroupBy(x => x.Age);
            foreach (var item in groupStu)
            {
                //外层循环获取到的是IGroup对象，里面有的是IGrouping<int,Student> int是Key值，分组的K值
                Console.WriteLine(item.Key);
                //每一组是一个集合，是集合就可以用聚合函数，这边把每一组里面的身高最大值取出来
                Console.WriteLine(item.Max(g=>g.Height));
                Console.WriteLine(item.Average(g=>g.Height));
                foreach (var stu in item)
                {
                    Console.WriteLine(stu.Name);
                }
                Console.WriteLine("===========");
            }

            Console.ReadLine();
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
