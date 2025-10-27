using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuralForge.Api.Entities
{
    [Table("assembly_lines")]
    public class AssemblyLine
    {
        [Key]
        [Column("assembly_line_id")]
        public int AssemblyLineId { get; set; }
        
        [Column("site_id")]
        [Required]
        public int SiteId { get; set; }
        
        [Column("chip_id")]
        [Required]
        public int ChipId { get; set; }
        
        [Column("number_of_machines")]
        public int? NumberOfMachines { get; set; }
        
        [Column("chips_per_hour")]
        [Required]
        public int ChipsPerHour { get; set; }
        
        public required Site Site { get; set; }
        
        public required Chip Chip { get; set; }
        
        public ICollection<DowntimeEvent> DowntimeEvents { get; set; } = new List<DowntimeEvent>();
        
        public ICollection<ProductionRecord> ProductionRecords { get; set; } = new List<ProductionRecord>();
    
    }
}

