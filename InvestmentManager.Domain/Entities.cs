namespace InvestmentManager.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Asset
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Type { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Fees { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Portfolio
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalValue { get; set; }
        public string AllocationTarget { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
