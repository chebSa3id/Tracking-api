using Microsoft.EntityFrameworkCore;
using Tracker_api.Models;

namespace Tracker_api.Data
{
    public class ApointmentDbContext : DbContext
    {
        public ApointmentDbContext(DbContextOptions<ApointmentDbContext> options) : base(options){ }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
