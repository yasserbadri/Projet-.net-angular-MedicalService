using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalAppointment.Models;

namespace MedicalAppointment.Services
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecord>> GetRecordsByPatientAsync(int patientId);
        Task<MedicalRecord> GetRecordByIdAsync(int id);
        Task AddMedicalRecordAsync(MedicalRecord record);
        Task UpdateMedicalRecordAsync(MedicalRecord record);
        Task DeleteMedicalRecordAsync(int id);
    }
}
