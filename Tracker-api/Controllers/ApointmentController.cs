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
        public async Task<IEnumerable<Appointment>> Get() {
            return await _context.Appointments.ToListAsync();
        }
        [HttpPost]
        public async Task<IEnumerable<Appointment>> Post()
        {
        }
    }
}
