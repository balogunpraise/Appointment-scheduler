using Dapper;
using TaskScheduler.Core.Entities;
using TaskScheduler.Infrastructure.Data.Repositories.Abstractions;

namespace TaskScheduler.Infrastructure.Data.Repositories.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DapperContext _context;

        public ScheduleRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            var query = "SELECT * FROM appointments";
            using(var connection = _context.CreateConnection())
            {
                var appointments = connection.QueryAsync<Appointment>(query);
                return await appointments;
            }
            
        }
    }
}
