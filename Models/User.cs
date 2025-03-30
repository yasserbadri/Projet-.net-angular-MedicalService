using Microsoft.AspNetCore.Identity;

namespace MedicalAppointment.Models
{
    public class User : IdentityUser  // Id est déjà défini dans IdentityUser (string)
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Patient,
        Doctor,
        Admin
    }
}
