using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MedicalAppointment.Models;
using MedicalAppointment.DTOs;

namespace MedicalAppointment.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) != null)
                return BadRequest(new { message = "Email already in use" });

            var user = new User
            {
                UserName = model.Email.Split('@')[0], // Générer un UserName unique
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Role = Enum.TryParse<UserRole>(model.Role, true, out var role) ? role : UserRole.Patient
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

            if (!result.Succeeded)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { message = "Login successful" });
        }
    }
}
