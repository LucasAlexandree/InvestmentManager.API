namespace InvestmentManager.Application.DTOs
{
    public class AssetDto
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}