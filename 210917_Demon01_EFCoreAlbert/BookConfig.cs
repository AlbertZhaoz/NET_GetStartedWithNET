using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210917_Demon01_EFCoreAlbert
{
    class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_Books");
            //例子
            //builder.ToTable("T_Books").HasIndex(e => e.Title);
            //builder.Ignore(b=>b.Price);
            //属性长度限制为20，且不可以为空。
            builder.Property(e => e.Title).HasMaxLength(100).IsRequired();
            builder.Property(e=>e.AuthorName).HasMaxLength(20).IsRequired();
            //builder.Property(e=>e.Title).HasMaxLength(30).IsRequired();
        }
    }
}
