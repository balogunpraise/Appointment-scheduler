using Microsoft.AspNetCore.Mvc;
using TaskScheduler.Api.Wrappers;
using TaskScheduler.Core.Entities;
using TaskScheduler.Infrastructure.Data.Repositories.Abstractions;

namespace TaskScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        [HttpGet(Name = "appointmnets")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointments()
        {
            var appointments = await _scheduleRepository.GetAppointments();
            return Ok(new ApiResponse<IEnumerable<Appointment>>(appointments, 200, "Succeeded"));
        }

        /*public async Task<Appointment> GetAppointmentById(string id)
        {
            
        }*/

        
    }
}
