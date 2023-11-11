using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(new Book
            {
                Id = 1,
                Name = "Epictetos",
                Description = "Filozof",
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                CategoryName = "Felsefe",
                Author = "Epictetos",
                Page = 96,
                Status = true,
            });
        }
    }
}
