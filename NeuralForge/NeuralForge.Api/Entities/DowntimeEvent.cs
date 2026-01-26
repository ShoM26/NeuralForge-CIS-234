using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuralForge.Api.Entities
{
    [Table("downtime_events")]
    public class DowntimeEvent
    {
        [Key]
        [Column("downtime_event_id")]
        public int DowntimeEventId { get; set; }
        
        [Column("assembly_line_id")]
        [Required]
        public int AssemblyLineId { get; set; }
        
        [Column("start_time")]
        [Required]
        public DateTime StartTime { get; set; }
        
        [Column("end_time")]
        [Required]
        public DateTime EndTime { get; set; }
    
        [Column("event_type")]
        public EventType? EventType { get; set; }
        
        public AssemblyLine AssemblyLine { get; set; }
    }
}

public enum EventType
{
    PowerLost=1,
    Maintenance=2,
    RoutineCleaning=3
}
