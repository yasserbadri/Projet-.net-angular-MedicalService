namespace MedicalAppointment.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }  // Relation avec l'utilisateur

    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed
    }

}
