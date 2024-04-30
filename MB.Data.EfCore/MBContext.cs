using MB.Data.EfCore.Mappings;
using MB.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MB.Data.EfCore
{
    public class MBContext : DbContext
    {
        public MBContext(DbContextOptions<MBContext> option) : base (option)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly( typeof(PersonMapping).Assembly );

            base.OnModelCreating(modelBuilder);
        }
    }
}