using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.Core.Entities;

namespace TaskScheduler.Infrastructure.Data.Repositories.Abstractions
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(string id);
        Task<Appointment> CreateAppointment(Appointment appointment);
    }
}
