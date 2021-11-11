using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _211101_Demo01_ScaffoldDbContext
{
    internal class Program
    {
        static void Main(string[] args)
        {              
            using (var ctx = new AlbertBookContext())
            {
                IQueryable<TBook> books = ctx.TBooks.OrderBy(e => e.Price);
                foreach (var item in books)
                {
                    System.Console.WriteLine(item.Title);
                }
                string sqlServerOrderByPrice = books.ToQueryString();
                System.Console.WriteLine("我是用ToQueryString查询出来的SQL语句："+sqlServerOrderByPrice);

                //查询出生日期年份为1998的前三个人的数据 Take取几条 Skip跳过几条
                var persons = ctx.TPeople.Where(p => p.BirthDay.Value.Year == 1998).Take(3);
                foreach (var item in persons)
                {
                    System.Console.WriteLine(item.Name);
                }
            }
        }
    }
}
