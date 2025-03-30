using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalAppointment.Models;
using MedicalAppointment.Services;
using MedicalAppointment.DTOs;

namespace MedicalAppointment.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointmentById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentRequest request)
        {
            var appointment = new Appointment
            {
                Date = request.Date,
                PatientId = request.PatientId,
                //Patient = request.Patient,
                DoctorId = request.DoctorId,
               // Doctor = request.Doctor,
                Description = request.Description,
                Status = request.Status
            };

            await _appointmentService.CreateAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.Id)
                return BadRequest();

            await _appointmentService.UpdateAppointmentAsync(appointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.CancelAppointmentAsync(id);
            return NoContent();
        }
    }
}
