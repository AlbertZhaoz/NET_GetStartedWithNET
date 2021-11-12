using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211101_Demo01_ScaffoldDbContext
{
    public class MySQL_AlbertBookContext: DbContext
    {
        public DbSet<TBook> Books { get; set; }
        public DbSet<TPerson> Persons { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<TCat> Cats { get; set; }
        public DbSet<TRabbit> Rabbits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                //If you wanna convert the C# code to MySQL, you should use the following package.
                //EFProvider-MySql PackageReference-Pomelo.EntityFrameworkCore.MySql
                // Replace with your connection string.
                var connectionString = "server=localhost;user=root;password=eason12138.;database=ef";
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
                optionsBuilder.UseMySql(connectionString, serverVersion);
                optionsBuilder.LogTo(msg => {
                    if (!msg.Contains("Executed DbCommand")) return;
                    Console.WriteLine(msg);
                    });
            }
           
            //string connStr = "Server = .; Database = AlbertBook; Trusted_Connection = True;MultipleActiveResultSets=true";
            //使用SqlServer连接数据库
            //optionsBuilder.UseSqlServer(connStr);
            //支持批量删除和操作数据库
            //optionsBuilder.UseBatchEF_MSSQL();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载所有的IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
