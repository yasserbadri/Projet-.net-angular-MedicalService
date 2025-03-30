namespace MedicalAppointment.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public User Patient { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RecordDetails { get; set; }
    }

}
