using Microsoft.AspNetCore.Mvc;
using PatientRegistriationSystem.DTOs;
using System.Net;
using PatientRegistriationSystem.Entities.Concrete;
using PatientRegistriationSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace PatientRegistriationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly patientregistrationsystemContext _context;

        public DoctorController(patientregistrationsystemContext DbContext)
        {
            this._context = DbContext;
        }

        //add doctor
        [HttpPost("AddDoctor")]
        public async Task<HttpStatusCode> Add(DoctorDto doctorDto)
        {
            var entity = new Doctor()
            {
                Id = doctorDto.Id,
                EmployeeId = doctorDto.EmployeeId
            };
            _context.Doctors.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        //get all doctors by id
        [HttpGet("GetDoctorsById")]
        public async Task<ActionResult<Doctor>> GetDoctorsById(int Id)
        {
            Doctor doctor = await _context.Doctors.Select(s => new Doctor
            {
                Id = s.Id
            }).FirstOrDefaultAsync(s => s.Id == Id);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                return doctor;
            }
        }
        //getAll doctors
        [HttpGet("GetAllDoctors")]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctors()
        {
            var List = await _context.Doctors.Select(
                s => new Doctor
                {
                    Id = s.Id,
                    EmployeeId = s.EmployeeId
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        //update doctors
        [HttpPut("UpdateDoctor")]
        public async Task<ActionResult<Doctor>> UpdateDoctor(Doctor doctor)
        {
            var entity = await _context.Doctors.FirstOrDefaultAsync(s => s.Id == doctor.Id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.EmployeeId = doctor.EmployeeId;
                await _context.SaveChangesAsync();
                return entity;
            }
        }


        // delete doctor
        [HttpDelete("DeleteDoctor/{Id}")]
        public async Task<HttpStatusCode> DeleteDoctor(int Id)
        {
            var entity = new Doctor()
            {
                Id = Id
            };
            _context.Doctors.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }

}
