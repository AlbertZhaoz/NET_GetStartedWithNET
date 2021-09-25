
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _210917_Demon01_EFCoreAlbert
{
    internal class Program
    {
        /// <summary>
        /// <see cref="InitDataBase(DbContext)"/>
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            //插入数据 ctx=逻辑上的数据库
            using (var ctx = new MyDbContext())
            {             
                var booksTable = ctx.Books;
                foreach (var item in booksTable)
                {
                    ctx.Remove(item);
                }               
                await ctx.SaveChangesAsync();
                //初始化数据表
                await InitDataBase(ctx);

                //查询
                var books = ctx.Books.Where(e => e.Price > 80);
                foreach (var item in books)
                {
                    Console.WriteLine(item.Title);
                }

                //查询是否存在一本叫Simple algorithm的书籍，如果存在则打印出作者名字
                var book = ctx.Books.Single(e => e.Title == "Simple algorithm");
                Console.WriteLine(book.AuthorName);

                books = ctx.Books.OrderBy(e => e.Price);
                foreach (var item in books)
                {
                    Console.WriteLine(item.Title);
                }

                //通过分组来取每一个作者的书数量和最大价格
                var groups = ctx.Books.GroupBy(e => e.AuthorName).Select(g => new
                {
                    Name = g.Key,
                    BooksCount = g.Count(),
                    MaxPrice = g.Max(e => e.Price)
                });
                foreach (var item in groups)
                {
                    Console.WriteLine($"Name:{item.Name}==" +
                        $"BooksCount:{item.BooksCount}==" +
                        $"MaxPrice:{item.MaxPrice}.");
                }
                //修改数据，albert作者的书籍的价格调高
                var albertBooks = ctx.Books.Where(e => e.AuthorName == "AlbertZhao");
                foreach (var item in albertBooks)
                {
                    item.Price = 198;
                }
                //删除书籍Top of the ware
                var cBook = ctx.Books.Single(e => e.Title == "Top of the ware");
                ctx.Remove(cBook);

                await ctx.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Init DataBase</remarks>
        /// <param name="ctx"></param>
        /// <returns></returns>
        static async Task InitDataBase(DbContext ctx)
        {
            Book b1 = new Book()
            {
                AuthorName = "AlbertZhao",
                Title = "Simple algorithm",
                Price = 99,
                PubTime = new DateTime(2022, 12, 1)
            };
            Book b2 = new Book()
            {
                AuthorName = "ZackYang",
                Title = "Zero-Based fun learning C",
                Price = 59.8,
                PubTime = new DateTime(2019, 3, 1)
            };
            Book b3 = new Book()
            {
                AuthorName = "WuJun",
                Title = "The beauty of math",
                Price = 99,
                PubTime = new DateTime(2018, 1, 1)
            };
            Book b4 = new Book()
            {
                AuthorName = "WuJun",
                Title = "Top of the ware",
                Price = 198,
                PubTime = new DateTime(2021, 1, 1)
            };
            Book b5 = new Book()
            {
                AuthorName = "Liangtongming",
                Title = "In-depth upderstanding of asp.net core",
                Price = 169,
                PubTime = new DateTime(2021, 1, 1)
            };

            //将对象数据添加到内存逻辑的数据表中
            await ctx.AddAsync(b1);
            await ctx.AddAsync(b2);
            await ctx.AddAsync(b3);
            await ctx.AddAsync(b4);
            await ctx.AddAsync(b5);

            //将内存中的数据同步到数据库里
            await ctx.SaveChangesAsync();
        }
    }
}
