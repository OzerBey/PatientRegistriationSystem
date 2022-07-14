using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientRegistriationSystem.DTOs;
using PatientRegistriationSystem.Entities;
using System.Net;

namespace PatientRegistriationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly patientregistrationsystemContext _context;

        public EmployeeController(patientregistrationsystemContext DbContext)
        {
            this._context = DbContext;
        }
        //add a new employee
        [HttpPost("AddEmployee")]
        public async Task<HttpStatusCode> InsertEmployee(EmployeeDto employeeDto)
        {

            var entity = new Employee()
            {
                AddressId = employeeDto.AddressId,
                NationalityId = employeeDto.NationalityId,
                Name = employeeDto.Name,
                Department = employeeDto.Department,
                PhotoId = employeeDto.PhotoId,
                Gender = employeeDto.Gender,
                PhoneNumber = employeeDto.PhoneNumber,
                DateOfBirth = employeeDto.DateOfBirth,
                Photo = employeeDto.Photo,
                Doctors = employeeDto.Doctors,
                Officers = employeeDto.Officers
            };
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        //get all employees
        [HttpGet("getAllEmployees")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var List = await _context.Employees.Select(
                s => new Employee
                {
                    Id = s.Id,
                    AddressId = s.AddressId,
                    NationalityId = s.NationalityId,
                    Name = s.Name,
                    Department = s.Department,
                    PhotoId = s.PhotoId,
                    Gender = s.Gender,
                    PhoneNumber = s.PhoneNumber,
                    DateOfBirth = s.DateOfBirth,
                    Photo = s.Photo,
                    Doctors = s.Doctors,
                    Officers = s.Officers
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

    }


}
