namespace InvestmentManager.Domain.Entities
{
    public class Asset
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Symbol { get; set; } // Ex: AAPL, PETR4
        public string Description { get; set; }
        public string Type { get; set; } // Ex: Ação, Fundo, Renda Fixa
        public decimal CurrentPrice { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}
