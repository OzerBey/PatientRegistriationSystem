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
        // GET: api/City
        [HttpGet("getAllCities")]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            return await _context.Cities.ToListAsync();
        }


    }
}
