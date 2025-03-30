using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalAppointment.Models;
using MedicalAppointment.Database;

namespace MedicalAppointment.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly ApplicationDbContext _context;

        public MedicalRecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalRecord>> GetRecordsByPatientAsync(int patientId)
        {
            return await _context.MedicalRecords
                                 .Where(r => r.PatientId == patientId)
                                 .ToListAsync();
        }

        public async Task<MedicalRecord> GetRecordByIdAsync(int id)
        {
            return await _context.MedicalRecords.FindAsync(id);
        }

        public async Task AddMedicalRecordAsync(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMedicalRecordAsync(MedicalRecord record)
        {
            _context.MedicalRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicalRecordAsync(int id)
        {
            var record = await _context.MedicalRecords.FindAsync(id);
            if (record != null)
            {
                _context.MedicalRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
