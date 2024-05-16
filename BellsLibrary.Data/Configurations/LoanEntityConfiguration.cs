using BellsLibrary.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BLM = BellsLibrary.Data.Models;



namespace BellsLibrary.Data.Configurations
{
    public class LoanEntityConfiguration : IEntityTypeConfiguration<BLM.Loan>
    {
        public void Configure(EntityTypeBuilder<BLM.Loan> builder)
        {
            builder.ToTable("Loan");

            builder.ConfigureBaseEntity();

            builder.HasOne(l => l.Book)
               .WithMany()
               .HasForeignKey(l => l.BookId);

            //builder.HasOne(User)
        }
    }
}
