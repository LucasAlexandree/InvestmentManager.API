namespace InvestmentManager.Domain.DTOs
{
    public class PortfolioOverviewDto
    {
        public decimal TotalValue { get; set; }
        public List<AssetDistributionDto> AssetDistribution { get; set; }
    }
}
