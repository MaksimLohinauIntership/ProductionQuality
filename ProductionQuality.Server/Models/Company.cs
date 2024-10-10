namespace ProductionQuality.Server.Models
{
    public class Company
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public List<decimal> PriceHistory { get; set; } = new List<decimal>();
        public Queue<PriceInformation> HistoryPrice { get; set; } = new Queue<PriceInformation>();
    }
}
