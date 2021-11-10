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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = .; Database = AlbertBook; Trusted_Connection = True;MultipleActiveResultSets=true");
                //optionsBuilder.UseLoggerFactory(loggerFactory);
                //optionsBuilder.LogTo(msg =>
                //{
                //    //msg是EF输出的消息
                //    Console.WriteLine(msg);
                //});
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
