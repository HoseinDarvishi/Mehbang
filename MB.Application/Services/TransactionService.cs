using MB.Contracts.DTOs;
using MB.Contracts.IServices;
using MB.Domain.IRepositories;

namespace MB.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository repo)
        {
            _transactionRepository = repo;
        }

        public async Task<PersonDto> GetMaxBuyerAsync(CancellationToken ct)
        {
            return await _transactionRepository.GetMaxBuyerAsync(ct);
        }

        public async Task<PersonDto> GetMaxBuyerAsync(PeriodDateDto period, CancellationToken ct)
        {
            var datePeriod = new PeriodDateTimeDto
            {
                Start_Date = DateTime.Parse(period.Start_Date),
                End_Date = DateTime.Parse(period.End_Date) + new TimeSpan(24,0,0)
            };

            return await _transactionRepository.GetMaxBuyerByDateAsync(datePeriod, ct);
        }

        public async Task<List<TransactionDto>> GetTransactionsAsync(int personId, CancellationToken ct)
        {
            return await _transactionRepository.GetTransactionsByPersonIdAsync(personId, ct);
        }

        public async Task<List<TransactionDto>> GetTransactionsAsync(CancellationToken ct)
        {
            return await _transactionRepository.GetTransactions(ct);
        }
    }
}