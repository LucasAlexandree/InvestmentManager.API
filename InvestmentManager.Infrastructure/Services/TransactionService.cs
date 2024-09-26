using InvestmentManager.Application.DTOs;
using InvestmentManager.Application.Interfaces;
using InvestmentManager.Domain.Entities;
using InvestmentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly InvestmentDbContext _context;

        public TransactionService(InvestmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync()
        {
            return await _context.Transactions
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    Date = t.Date,
                    Quantity = t.Quantity,
                    PricePerUnit = t.PricePerUnit,
                    Fees = t.Fees
                }).ToListAsync();
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return null;

            return new TransactionDto
            {
                Id = transaction.Id,
                Date = transaction.Date,
                Quantity = transaction.Quantity,
                PricePerUnit = transaction.PricePerUnit,
                Fees = transaction.Fees
            };
        }

        public async Task<TransactionDto> CreateTransactionAsync(TransactionDto transactionDto)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Date = transactionDto.Date,
                Quantity = transactionDto.Quantity,
                PricePerUnit = transactionDto.PricePerUnit,
                Fees = transactionDto.Fees
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return new TransactionDto
            {
                Id = transaction.Id,
                Date = transaction.Date,
                Quantity = transaction.Quantity,
                PricePerUnit = transaction.PricePerUnit,
                Fees = transaction.Fees
            };
        }

        public async Task UpdateTransactionAsync(TransactionDto transactionDto)
        {
            var transaction = await _context.Transactions.FindAsync(transactionDto.Id);
            if (transaction == null) return;

            transaction.Date = transactionDto.Date;
            transaction.Quantity = transactionDto.Quantity;
            transaction.PricePerUnit = transactionDto.PricePerUnit;
            transaction.Fees = transactionDto.Fees;

            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return;

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
