using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeuralForge.Api.Data;
using NeuralForge.Api.Entities;
using NeuralForge.Api.Dtos.ProductionRecord;

namespace NeuralForge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductionRecordController : ControllerBase
    {
        private readonly NeuralForgeContext _context;

        public ProductionRecordController(NeuralForgeContext context)
        {
            _context = context;
        }
        //Health
        
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
        }
        //POST: api/ProductionRecord
        [HttpPost]
        public async Task<IActionResult> Create(ProductionRecordRequestDto dto)
        {
            try
            {
                var entity = new ProductionRecord
                {
                    AssemblyLineId = dto.AssemblyLineId,
                    HourOfDay = dto.HourOfDay,
                    NumberOfChips = dto.NumberOfChips
                };
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
    }
}

