using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string PatientId { get; set; }  // Seul l'ID est requis

        public User Patient { get; set; }      // Ne doit pas être requis

        [Required]
        public string DoctorId { get; set; }   // Seul l'ID est requis

        public User Doctor { get; set; }       // Ne doit pas être requis

        public AppointmentStatus Status { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }

}
