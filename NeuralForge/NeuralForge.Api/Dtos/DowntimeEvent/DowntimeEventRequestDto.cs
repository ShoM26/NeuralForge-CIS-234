namespace NeuralForge.Api.Dtos.DowntimeEvent
{
    public class DowntimeEventRequestDto
    {
        public int AssemblyLineId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public EventType? EventType { get; set; }
    }
}
