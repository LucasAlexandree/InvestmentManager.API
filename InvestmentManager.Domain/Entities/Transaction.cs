namespace InvestmentManager.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AssetId { get; set; } // Referência ao ativo negociado
        public string Type { get; set; } // Compra ou Venda
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Fees { get; set; }
        public DateTime Date { get; set; }

        // Relação com a entidade Asset
        public Asset Asset { get; set; }
    }
}
