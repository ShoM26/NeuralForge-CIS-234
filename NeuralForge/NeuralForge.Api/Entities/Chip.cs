using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        [MaxLength(255)]
        public string ChipName { get; set; }
        
        [Column("number_of_cores")]
        [Required]
        public int NumberOfCores { get; set; }
        
        [Column("production_time")]
        [Required]
        [Precision(18,2)]
        public double ProductionTime { get; set; } //in minutes
        
        [Column("market_price")]
        [Required]
        [Precision(18,2)]
        public double MarketPrice { get; set; }
        
        public ICollection<AssemblyLine> AssemblyLines { get; set; } = new List<AssemblyLine>();
    }
}

