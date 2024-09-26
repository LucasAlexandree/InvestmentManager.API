using InvestmentManager.Domain.DTOs;

namespace InvestmentManager.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<PortfolioOverviewDto> GetPortfolioOverviewAsync(Guid userId);
    }
}
