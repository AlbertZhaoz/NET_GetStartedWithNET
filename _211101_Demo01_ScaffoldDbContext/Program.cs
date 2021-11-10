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
                var books = ctx.TBooks.OrderBy(e => e.Price);
                foreach (var item in books)
                {
                    System.Console.WriteLine(item.Title);
                }
                string sqlServerOrderByPrice = books.ToQueryString();
                System.Console.WriteLine(sqlServerOrderByPrice);
            }
        }
    }
}
