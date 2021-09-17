using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _20170713_Demon01_TaskWhenAll
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string[] filename = Directory.GetFiles(@"C:\01_AlbertCode\NET\NETCoreWinform");
            Task<int>[] countTask = new Task<int>[filename.Length];
            //开启n个Task，然后将Task放在Task数组中，用WhenAll等待所有数组Task执行完毕
            for (int i = 0; i < filename.Length; i++)
            {
                string file = filename[i];
                Task<int> t = ReadCharCount(file);
                countTask[i] = t;
            }
            int[] counts = await Task.WhenAll(countTask);
            Console.WriteLine(counts.Sum());//计算数组的和 Linq
            Console.ReadLine();
        }

        //将文件夹下所有文件的字符个数汇总出来
        static async Task<int> ReadCharCount(string filename)
        {
            string s = await File.ReadAllTextAsync(filename);
            return s.Length;
        }
    }
}
