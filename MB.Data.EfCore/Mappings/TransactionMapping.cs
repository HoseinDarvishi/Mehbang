using MB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Data.EfCore.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.TransactionId);
            builder.Property(x => x.TransactionDate);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
