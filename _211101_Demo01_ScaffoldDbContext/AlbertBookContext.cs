using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace _211101_Demo01_ScaffoldDbContext
{
    public partial class AlbertBookContext : DbContext
    {
        private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder=>builder.AddConsole());
        public IServiceProvider Services { get; set; }

        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<TBook> TBooks { get; set; }
        public virtual DbSet<TCat> TCats { get; set; }
        public virtual DbSet<TPerson> TPeople { get; set; }
        public virtual DbSet<TRabbit> TRabbits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //If you wanna convert the C# code to SQLServer, you should use the following package.
                //EFProvider-SQLServer PackageReference-Microsoft.EntityFrameworkCore.SqlServer
                //optionsBuilder.UseSqlServer("Server = .; Database = AlbertTemp; Trusted_Connection = True;MultipleActiveResultSets=true");

                //If you wanna convert the C# code to MySQL, you should use the following package.
                //EFProvider-MySql PackageReference-Pomelo.EntityFrameworkCore.MySql
                // Replace with your connection string.
                var connectionString = "server=localhost;user=root;password=eason12138.;database=AlbertTBooks";
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

                optionsBuilder.UseMySql(connectionString, serverVersion);


                //标准日志 Package-Microsoft.Extensions.Logging
                //optionsBuilder.UseLoggerFactory(loggerFactory);
                optionsBuilder.LogTo(msg =>
                {
                    if(!msg.Contains("Executing DbCommand")){ return; }
                    //msg是ef输出的消息
                    Console.WriteLine(msg);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<TBook>(entity =>
            {
                entity.ToTable("T_Books");

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TCat>(entity =>
            {
                entity.ToTable("T_Cats");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TPerson>(entity =>
            {
                entity.ToTable("T_Person");
            });

            modelBuilder.Entity<TRabbit>(entity =>
            {
                entity.ToTable("T_Rabbit");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
