using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalAppointment.Models;

namespace MedicalAppointment.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task CreateAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task CancelAppointmentAsync(int id);
    }
}
