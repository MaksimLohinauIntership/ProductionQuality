using System.ComponentModel.DataAnnotations;

namespace ProductionQuality.Models
{
    public class Company
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Price { get; set; }
        public List<int> PriceHistory { get; set; } = new List<int>();
    }
}
