using InvestmentManager.Application.Interfaces;
using InvestmentManager.Domain.Entities;
using InvestmentManager.Infrastructure.Data;
using InvestmentManager.Infrastructure.Data.InvestmentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAssetIdAsync(Guid assetId)
        {
            return await _context.Transactions
                                 .Where(t => t.AssetId == assetId)
                                 .ToListAsync();
        }

        public async Task<bool> RemoveTransactionAsync(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return false;

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
