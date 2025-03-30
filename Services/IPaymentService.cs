using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalAppointment.Models;

namespace MedicalAppointment.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId);
        Task<bool> ProcessPaymentAsync(Payment payment);
        Task<bool> UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(int id);

    }
}
