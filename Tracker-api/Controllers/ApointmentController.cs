using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracker_api.Data;
using Tracker_api.Models;

namespace Tracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApointmentController : ControllerBase
    {
        private readonly ApointmentDbContext _context;
        public ApointmentController(ApointmentDbContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<Appointment>> Get()
        {
            return await _context.Appointments.ToListAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Appointment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            return appointment == null ? NotFound() : Ok(appointment);
        }
        [HttpGet("search/{date}")]
        [ProducesResponseType(typeof(Appointment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitle(string date)
        {
            var appointment = await _context.Appointments.SingleOrDefaultAsync(c => c.Date == date);
            return appointment == null ? NotFound() : Ok(appointment);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Appointment appointment)
        {
            if (id != appointment.Id) return BadRequest();

            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var appointmentToDelete = await _context.Appointments.FindAsync(id);
            if (appointmentToDelete == null) return NotFound();

            _context.Appointments.Remove(appointmentToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
