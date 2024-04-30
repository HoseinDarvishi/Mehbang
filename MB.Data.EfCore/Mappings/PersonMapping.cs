using Microsoft.EntityFrameworkCore;
using MB.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Data.EfCore.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.PersonId);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Family).IsRequired().HasMaxLength(256);

            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
