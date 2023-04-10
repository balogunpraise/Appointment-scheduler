using System.ComponentModel.DataAnnotations.Schema;

namespace TaskScheduler.Core.Entities
{
    public class Client
    {
        [ForeignKey("Appointment")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDepricatied { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
