using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalAppointment.Models;
using MedicalAppointment.Services;

namespace MedicalAppointment.Controllers
{
    [Route("api/medicalrecords")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpGet("{patientId}")]
        public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetRecordsByPatient(int patientId)
        {
            var records = await _medicalRecordService.GetRecordsByPatientAsync(patientId);
            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicalRecord([FromBody] MedicalRecord record)
        {
            await _medicalRecordService.AddMedicalRecordAsync(record);
            return CreatedAtAction(nameof(GetRecordsByPatient), new { patientId = record.PatientId }, record);
        }
    }
}
