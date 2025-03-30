namespace MedicalAppointment.DTOs
{
    public class RegisterDto
    {
        public string FirstName { get; set; } = string.Empty; // Ajouté
        public string LastName { get; set; } = string.Empty;  // Ajouté
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Patient"; // Ajouté avec valeur par défaut
    }
}
