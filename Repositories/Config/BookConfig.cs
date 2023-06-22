using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WebApplication11.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<book>
    {
        public void Configure(EntityTypeBuilder<book> builder)
        {
            builder.HasData(
                new book { bookId = 1, name = "alice harikalar diyarinda", price = 50},
                new book { bookId = 2, name = "saftirik greg", price = 100 },
                new book { bookId = 3, name = "barbie", price = 80 }
                );
        }
    }
}
