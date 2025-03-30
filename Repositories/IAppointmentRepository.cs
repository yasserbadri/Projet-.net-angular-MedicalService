using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalAppointment.Models;

namespace MedicalAppointment.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int id);
    }
}
