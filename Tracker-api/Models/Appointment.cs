using System.ComponentModel.DataAnnotations;

namespace Tracker_api.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }

    }
}
