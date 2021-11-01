
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

                //找到所有书籍然后价格高于60的都涨价1块钱
                var albertBooks2 = ctx.Books.Where(e => e.Price > 60);
                foreach (var item in albertBooks2)
                {
                    item.Price = item.Price + 2;
                }

                // 测试自增主键
                Dog dog = new Dog();
                dog.Name = "DogOne";
                Console.WriteLine($"我是自增主键{dog.Id}");
                await ctx.AddAsync(dog);
                await ctx.SaveChangesAsync(); //自增的数据是数据赋值
                Console.WriteLine($"我是自增主键{dog.Id}");

                Guid guid = Guid.NewGuid();
                Console.WriteLine(guid);
                Console.WriteLine(guid.ToString());


                //插入数据不适用指定值
                Rabbit rabbit = new Rabbit();
                rabbit.Name = "yzk";
                Console.WriteLine(rabbit.Id);
                ctx.Add(rabbit); //EFCore引擎来给Guid字段赋值
                Console.WriteLine(rabbit.Id);
                await ctx.SaveChangesAsync();
                Console.WriteLine(rabbit.Id);

                //使用杨中科老师的Nuget包:Zack.EFCore.Batch进行批量删除和更新数据
                await ctx.DeleteRangeAsync<Book>(e => e.Price > 80 && e.AuthorName == "WuJun");
                await ctx.BatchUpdate<Book>()
     .Set(b => b.Price, b => b.Price + 3)
     .Set(b => b.Title, b => "HelloWorld")
     .Set(b => b.AuthorName, b => b.Title.Substring(3, 2) + b.AuthorName.ToUpper())
     .Set(b => b.PubTime, b => DateTime.Now)
     .Where(b => b.Id > 1 || b.AuthorName.StartsWith("Albert"))
     .ExecuteAsync();
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
