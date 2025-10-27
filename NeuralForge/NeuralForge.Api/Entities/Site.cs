using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuralForge.Api.Entities
{
    [Table("sites")]
    public class Site
    {
        [Key]
        [Column("site_id")]
        public int SiteId { get; set; }
        
        [Column("location")]
        [Required]
        [MaxLength(255)]
        public string Location { get; set; }
        
        [Column("number_of_lines")]
        [Required]
        public int NumberOfLines { get; set; }
        
        [Column("chips_per_hour")]
        [Required]
        public int ChipsPerHour { get; set; }

        public ICollection<AssemblyLine> AssemblyLines { get; set; } = new List<AssemblyLine>();
    }   
}