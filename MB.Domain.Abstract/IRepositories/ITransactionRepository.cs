using MB.Contracts.DTOs;

namespace MB.Domain.IRepositories
{
    public interface ITransactionRepository
    {
        Task<List<TransactionDto>> GetTransactionsByPersonIdAsync(int personId, CancellationToken ct);
        Task<List<TransactionDto>> GetTransactions(CancellationToken ct);
        Task<PersonDto> GetMaxBuyerAsync(CancellationToken ct);
        Task<PersonDto> GetMaxBuyerByDateAsync(PeriodDateTimeDto perid , CancellationToken ct);
    }
}
