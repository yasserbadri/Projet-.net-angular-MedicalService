using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalAppointment.Models;
using MedicalAppointment.Services;

namespace MedicalAppointment.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // POST: api/payments
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] Payment payment)
        {
            var result = await _paymentService.ProcessPaymentAsync(payment);
            if (!result)
                return BadRequest("Payment failed");

            return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
        }

        // GET: api/payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        // GET: api/payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // PUT: api/payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payment payment)
        {
            if (id != payment.Id)
                return BadRequest("ID mismatch");

            var result = await _paymentService.UpdatePaymentAsync(payment);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await _paymentService.DeletePaymentAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}