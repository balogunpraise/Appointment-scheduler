using Dapper;
using System.Data;
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

        public async Task<Appointment> GetAppointmentById(string id)
        {
            var query = "SELECT a.* FROM appointments a WHERE a.id = @id";
            using(var connection = _context.CreateConnection())
            {
                var appointment = await connection.QuerySingleOrDefaultAsync<Appointment>(query, new {id});
                return appointment;
            }
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            var query = "INSERT INTO appointments (Title, Details," +
                "SceduledFor, EndsAt, IsMissedAppointment, IsCompleted," +
                "IsDepricated, Price, ClientId) VALUES (@title, @details, @scheduledfor, @endsat, @ismissedappointment," +
                "@iscompleted, @isdepricated, @price, @clientid) SELECT CAST(SCOPE_IDENTITY() AS VARCHAR)";

            var parameters = new DynamicParameters();
            parameters.Add("title", appointment.Title, DbType.String);
            parameters.Add("details", appointment.Details, DbType.String);
            parameters.Add("sheduledfor", appointment.SheduledFor, DbType.DateTime);
            parameters.Add("endsat", appointment.EndsAt, DbType.DateTime);
            parameters.Add("ismissedappointment", appointment.IsMissedAppointment, DbType.Boolean);
            parameters.Add("iscompleted", appointment.IsCompleted, DbType.Boolean);
            parameters.Add("isdepricated", appointment.IsDepricatied, DbType.Boolean);
            parameters.Add("price", appointment.Price, DbType.Decimal);
            parameters.Add("clientid", appointment.ClientId, DbType.String);

            using(var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<string>(query, parameters);
                var response = new Appointment
                {
                    Id = id,
                    Title = appointment.Title,
                    Details = appointment.Details,
                    SheduledFor = appointment.SheduledFor,
                    EndsAt = appointment.EndsAt,
                    IsMissedAppointment = appointment.IsMissedAppointment,
                    IsCompleted = appointment.IsCompleted,
                    IsDepricatied = appointment.IsDepricatied,
                    Price = appointment.Price,
                    ClientId = appointment.ClientId,
                };
                return response;
            }
        }
    }
}
