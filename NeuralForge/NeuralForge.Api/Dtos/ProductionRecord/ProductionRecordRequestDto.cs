namespace NeuralForge.Api.Dtos.ProductionRecord
{
    public class ProductionRecordRequestDto
    {
        public int AssemblyLineId { get; set; }
        public int NumberOfChips { get; set; }
        public DateTime HourOfDay { get; set; }
    }
}
