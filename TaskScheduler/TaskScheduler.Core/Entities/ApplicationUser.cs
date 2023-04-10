using Microsoft.AspNetCore.Identity;

namespace TaskScheduler.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessId { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
