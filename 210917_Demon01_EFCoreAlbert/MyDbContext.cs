using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210917_Demon01_EFCoreAlbert
{
    public class MyDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons {  get; set; }
        public DbSet<Dog> Dogs { get;set;  }
        public DbSet<Cat> Cats {  get; set; }
        public DbSet<Rabbit> Rabbits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = "Server = .; Database = AlbertBook; Trusted_Connection = True;MultipleActiveResultSets=true";
            //使用SqlServer连接数据库
            optionsBuilder.UseSqlServer(connStr);
            //支持批量删除和操作数据库
            optionsBuilder.UseBatchEF_MSSQL();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载所有的IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
