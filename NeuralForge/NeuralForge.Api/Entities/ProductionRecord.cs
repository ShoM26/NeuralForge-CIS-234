using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuralForge.Api.Entities
{
    [Table("production_records")]
    public class ProductionRecord
    {
        [Key]
        [Column("production_record_id")]
        public int ProductionRecordId { get; set; }
        
        [Column("assembly_line_id")]
        [Required]
        public int AssemblyLineId { get; set; }
        
        [Column("number_of_chips")]
        [Required]
        public int NumberOfChips { get; set; }
        
        [Column("hour_of_day")]
        [Required]
        public DateTime HourOfDay { get; set; }
        
        public AssemblyLine AssemblyLine { get; set; }
    }
}
