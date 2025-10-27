using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuralForge.Api.Entities
{
    [Table("chips")]
    public class Chip
    {
        [Key]
        [Column("chip_id")]
        public int ChipId { get; set; }
    
        [Column("chip_name")]
        [Required]
        public string ChipName { get; set; }
        
        [Column("number_of_cores")]
        [Required]
        public int NumberOfCores { get; set; }
        
        [Column("production_time")]
        [Required]
        public double ProductionTime { get; set; } //in minutes
        
        [Column("market_price")]
        [Required]
        public double MarketPrice { get; set; }
    }
}

