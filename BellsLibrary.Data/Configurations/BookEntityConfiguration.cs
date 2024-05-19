using BellsLibrary.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BLM = BellsLibrary.Data.Models;



namespace BellsLibrary.Data.Configurations
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<BLM.Book>
    {
        public void Configure(EntityTypeBuilder<BLM.Book> builder)
        {
            builder.ToTable("Book");

            builder.ConfigureBaseEntity();
        }
    }
}
