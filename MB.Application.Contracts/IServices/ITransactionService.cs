using MB.Contracts.DTOs;

namespace MB.Contracts.IServices
{
    public interface ITransactionService
    {
        Task<List<TransactionDto>> GetTransactionsAsync(int personId, CancellationToken ct);
        Task<List<TransactionDto>> GetTransactionsAsync(CancellationToken ct);
        Task<PersonDto> GetMaxBuyerAsync(CancellationToken ct);
        Task<PersonDto> GetMaxBuyerAsync(PeriodDateDto period, CancellationToken ct);
    }
}
