using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientRegistriationSystem.DTOs;
using PatientRegistriationSystem.Entities;
using PatientRegistriationSystem.Entities.Concrete;
using System.Net;

namespace PatientRegistriationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly patientregistrationsystemContext _context;
        public PatientController(patientregistrationsystemContext DbContext)
        {
            this._context = DbContext;
        }
        //add a new patient
        [HttpPost("AddPatient")]
        public async Task<HttpStatusCode> InsertPatient(PatientDto patientDto)
        {
            var entity = new Patient()
            {
                AddressId = patientDto.AddressId,
                NationalityId = patientDto.NationalityId,
                Name = patientDto.Name,
                PhotoId = patientDto.PhotoId,
                Gender = patientDto.Gender,
                PhoneNumber = patientDto.PhoneNumber,
                DateOfBirth = patientDto.DateOfBirth
            };
            _context.Patients.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        //get all patients by id
        [HttpGet("GetPatientsById")]
        public async Task<ActionResult<IEnumerable<Patient>>> Get(int id)
        {
            return await _context.Patients.Where(x => x.Id == id).ToListAsync();
        }



        //get all patients
        [HttpGet("GetAllPatients")]
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            return await _context.Patients.ToListAsync();
        }

    }
}
