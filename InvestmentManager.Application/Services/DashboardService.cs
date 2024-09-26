using InvestmentManager.Application.Interfaces;
using InvestmentManager.Domain.DTOs;
using InvestmentManager.Infrastructure.Data;
using InvestmentManager.Infrastructure.Data.InvestmentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PortfolioOverviewDto> GetPortfolioOverviewAsync(Guid userId)
        {
            // Obter os ativos e transações do usuário
            var assets = await _context.Assets
                                       .Include(a => a.Transactions)
                                       .Where(a => a.UserId == userId)
                                       .ToListAsync();

            // Calcular o valor total da carteira
            var totalValue = assets.Sum(a => a.Transactions
                                           .Where(t => t.Type == "Compra")
                                           .Sum(t => t.Quantity * t.UnitPrice));

            // Calcular a distribuição por tipo de ativo
            var assetDistribution = assets.GroupBy(a => a.Type)
                                          .Select(g => new AssetDistributionDto
                                          {
                                              AssetType = g.Key,
                                              TotalValue = g.Sum(a => a.Transactions.Sum(t => t.Quantity * t.UnitPrice))
                                          }).ToList();

            // Retornar os dados do dashboard
            return new PortfolioOverviewDto
            {
                TotalValue = totalValue,
                AssetDistribution = assetDistribution
            };
        }
    }
}
