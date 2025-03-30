using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalAppointment.Models;
using MedicalAppointment.Database;

namespace MedicalAppointment.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            return await _context.Payments
                               .Where(p => p.UserId == userId)
                               .ToListAsync();
        }

        public async Task<bool> ProcessPaymentAsync(Payment payment)
        {
            try
            {
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatePaymentAsync(Payment payment)
        {
            try
            {
                _context.Entry(payment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            try
            {
                var payment = await _context.Payments.FindAsync(id);
                if (payment == null)
                    return false;

                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}