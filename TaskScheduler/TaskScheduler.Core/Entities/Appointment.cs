using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.Core.Entities
{
    public class Appointment : BaseEntity
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
        public  string ApplicationUserId { get; set; }
        public Client Client { get; set; }
    }
}
