using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientRegistriationSystem.DTOs;
using PatientRegistriationSystem.Entities;
using System.Net;

namespace PatientRegistriationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly patientregistrationsystemContext _context;

        public CityController(patientregistrationsystemContext DbContext)
        {
            this._context = DbContext;
        }
        //add city
        [HttpPost("AddCity")]
        public async Task<HttpStatusCode> Add(CityDto cityDto)
        {
            var entity = new City()
            {
                Name = cityDto.Name
            };
            _context.Cities.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        //get city by id
        [HttpGet("GetCityById")]
        public async Task<ActionResult<City>> GetCityById(int Id)
        {
            City city = await _context.Cities.Select(s => new City
            {
                Id = s.Id,
                Name = s.Name
            }).FirstOrDefaultAsync(s => s.Id == Id);
            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return city;
            }
        }

        // getAll: api/City
        [HttpGet("getAllCities")]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            return await _context.Cities.ToListAsync();
        }
        //update city
        [HttpPut("UpdateCity")]
        public async Task<ActionResult<City>> UpdateCity(City city)
        {
            var entity = await _context.Cities.FirstOrDefaultAsync(s => s.Id == city.Id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.Name = city.Name;
                await _context.SaveChangesAsync();
                return entity;
            }
        }

        //delete city
        [HttpDelete("DeleteUser/{Id}")]
        public async Task<HttpStatusCode> DeleteCity(int Id)
        {
            var entity = new City()
            {
                Id = Id
            };
            _context.Cities.Attach(entity);
            _context.Cities.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


    }
}
