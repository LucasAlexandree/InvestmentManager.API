using InvestmentManager.Application.DTOs;

namespace InvestmentManager.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();
        Task<TransactionDto> GetTransactionByIdAsync(Guid id);
        Task<TransactionDto> CreateTransactionAsync(TransactionDto transactionDto);
        Task UpdateTransactionAsync(TransactionDto transactionDto);
        Task DeleteTransactionAsync(Guid id);
    }
}
