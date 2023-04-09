using Microsoft.AspNetCore.Identity;

namespace TaskScheduler.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string BusinessId { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
