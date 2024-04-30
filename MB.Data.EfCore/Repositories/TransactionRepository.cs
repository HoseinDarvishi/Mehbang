using MB.Contracts.DTOs;
using MB.Domain.IRepositories;
using MB.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MB.Data.EfCore.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MBContext _context;

        public TransactionRepository(MBContext context)
        {
            _context = context;
        }

        public async Task<PersonDto> GetMaxBuyerAsync(CancellationToken ct)
        {
            var person = await _context.Persons
                .Include(x=>x.Transactions)
                .OrderByDescending(x => x.Transactions.Sum(z => z.Price))
                .Select(x=> new PersonDto
                {
                    PersonId = x.PersonId,
                    Name = x.Name,
                    Family = x.Family,
                    SumPrice = x.Transactions.Sum(z => z.Price)
                })
                .FirstOrDefaultAsync(ct);

            return person;
        }

        public async Task<PersonDto> GetMaxBuyerByDateAsync(PeriodDateTimeDto period, CancellationToken ct)
        {
            var person = _context.Persons
                .Include(x => x.Transactions)
                .Select(x => new PersonDto
                {
                    Name = x.Name,
                    Family = x.Family,
                    PersonId = x.PersonId,
                    SumPrice = x.Transactions.Where(x => x.TransactionDate >= period.Start_Date && x.TransactionDate <= period.End_Date).Sum(z => z.Price)
                })
                .OrderByDescending(x => x.SumPrice)
                .FirstOrDefaultAsync();

            return await person;
        }

        public async Task<List<TransactionDto>> GetTransactions(CancellationToken ct)
        {
            var transactions = await _context.Transactions
                .Include(x => x.Person)
                .Select(x => new TransactionDto
                {
                    PersonId = x.PersonId,
                    Date = x.TransactionDate,
                    Price = x.Price,
                    PersonName = x.Person.Name,
                    PersonFamily = x.Person.Family
                })
                .ToListAsync(ct);

            return transactions;
        }

        public async Task<List<TransactionDto>> GetTransactionsByPersonIdAsync(int personId, CancellationToken ct)
        {
            var transactions = await _context.Transactions
                .Include(x=>x.Person)
                .Where(x => x.PersonId == personId)
                .Select(x=> new TransactionDto
                {
                    PersonId = x.PersonId,
                    Date = x.TransactionDate,
                    Price = x.Price,
                    PersonName = x.Person.Name,
                    PersonFamily = x.Person.Family
                })
                .ToListAsync(ct);

            return transactions;
        }
    }
}