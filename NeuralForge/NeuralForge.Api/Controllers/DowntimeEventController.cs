using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeuralForge.Api.Data;
using NeuralForge.Api.Entities;
using NeuralForge.Api.Dtos.DowntimeEvent;

namespace NeuralForge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DowntimeEventController : ControllerBase
    {
        private readonly NeuralForgeContext _context;

        public DowntimeEventController(NeuralForgeContext context)
        {
            _context = context;
        }
        //Health
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
        }
        //POST: api/DowntimeEvent
        [HttpPost]
        public async Task<IActionResult> Create(DowntimeEventRequestDto dto)
        {
            try
            {
                var entity = new DowntimeEvent
                {
                    AssemblyLineId = dto.AssemblyLineId,
                    StartTime = dto.StartTime,
                    EndTime = dto.EndTime,
                    EventType = dto?.EventType,
                };
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
    }
}

