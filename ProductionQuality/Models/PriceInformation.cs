using System.ComponentModel.DataAnnotations;

namespace ProductionQuality.Models
{
    public class PriceInformation
    {
        [Required]
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

    }
}
