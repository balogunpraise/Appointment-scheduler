using TaskScheduler.Core.Entities;

namespace TaskScheduler.Api.dtos.RequestDtos
{
    public class AddAppointmentDto
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime SheduledFor { get; set; }
        public DateTime EndsAt { get; set; }
        public bool IsMissedAppointment { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDepricatied { get; set; }
        public decimal Price { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
