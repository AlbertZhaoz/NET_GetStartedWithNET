using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211118_Demo01_GolangCSharpImplement
{
    internal class FileExtensions
    {
        public string FilePath { get; set; }

        public FileExtensions(string filePath)
        {
            this.FilePath = filePath;
        }

        public async Task ReadFileOne()
        {
            var content = await File.ReadAllTextAsync(FilePath);
            Console.WriteLine(content);
        }

        public void ReadFileByBuffer()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string? line = "";
                    //同步读取和异步读取的案例https://docs.microsoft.com/zh-cn/dotnet/api/system.io.streamreader?view=net-6.0
                    while ((line = sr.ReadLine())!= null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
