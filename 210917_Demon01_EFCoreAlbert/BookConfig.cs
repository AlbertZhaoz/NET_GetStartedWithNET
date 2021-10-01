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
            builder.ToTable("T_Books").Property(e=>e.Title).HasMaxLength(40).IsRequired();
            builder.Property(e=>e.AuthorName).HasMaxLength(20).IsRequired();
            builder.Property(e=>e.Title).HasMaxLenth(30).IsRequired();
        }
    }
}
