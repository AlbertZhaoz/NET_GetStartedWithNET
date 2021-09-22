using System;
using System.IO;
using System.Threading.Tasks;

namespace _210922_Demon01_WriteTextToFile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\v-honzhao\Desktop\New folder\access.log");
            using StreamWriter new_file = new StreamWriter(@"D:\IP - Copy.txt", append: true);
            while ((line = file.ReadLine()) != null)
            {
                string[] array = line.Trim().Split(" ");
                System.Console.WriteLine(array[0]);
                await new_file.WriteLineAsync($"{array[0]}");
                counter++;
            }

            file.Close();
            System.Console.WriteLine($"There were {counter} lines.");
            System.Console.ReadLine();
        }
    }
}
