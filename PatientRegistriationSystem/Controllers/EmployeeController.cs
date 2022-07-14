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

        //get all employee by id
        [HttpGet("GetEmployeeById")]
        public async Task<ActionResult<Employee>> GetEmployeesById(int Id)
        {
            Employee employee = await _context.Employees.Select(s => new Employee
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
            }).FirstOrDefaultAsync(s => s.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return employee;
            }
        }

        //get all employees
        [HttpGet("getAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await _context.Employees.ToListAsync();
        }

        //update employee
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(s => s.Id == employee.Id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.AddressId = employee.AddressId;
                entity.NationalityId = employee.NationalityId;
                entity.Name = employee.Name;
                entity.Department = employee.Department;
                entity.PhotoId = employee.PhotoId;

            }
            await _context.SaveChangesAsync();
            return entity;
        }

        //delete employee
        [HttpDelete("DeleteEmployee/{Id}")]
        public async Task<HttpStatusCode> DeleteEmployee(int Id)
        {
            var entity = new Employee()
            {
                Id = Id
            };
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
