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
    public class AddressController : ControllerBase
    {
        private readonly patientregistrationsystemContext _context;

        public AddressController(patientregistrationsystemContext DbContext)
        {
            this._context = DbContext;
        }

        //add a new address
        [HttpPost("AddAdress")]
        public async Task<HttpStatusCode> AddAddress(AddressDto addressDto)
        {

            var entity = new Address()
            {
                CityId = addressDto.CityId,
                Street = addressDto.Street,
                BuildingNo = addressDto.BuildingNo
            };
            _context.Addresses.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        // getAll Addresses
        [HttpGet("getAllAddresses")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAll()
        {
            return await _context.Addresses.ToListAsync();
        }

        //get addresses by id
        [HttpGet("GetAddressById")]
        public async Task<ActionResult<Address>> GetAddressById(int Id)
        {
            Address address = await _context.Addresses.Select(s => new Address
            {
                Id = s.Id,
                CityId = s.CityId,
                Street = s.Street,
                BuildingNo = s.BuildingNo
            }).FirstOrDefaultAsync(s => s.Id == Id);
            if (address == null)
            {
                return NotFound();
            }
            else
            {
                return address;
            }
        }

        //update address
        [HttpPut("UpdateAddress")]
        public async Task<ActionResult<Address>> UpdateAddress(Address address)
        {
            var entity = await _context.Addresses.FirstOrDefaultAsync(s => s.Id == address.Id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.CityId = address.CityId;
                entity.Street = address.Street;
                entity.BuildingNo = address.BuildingNo;
                _context.Addresses.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
        }

        //delete address
        [HttpDelete("DeleteAddress/{Id}")]
        public async Task<HttpStatusCode> DeleteAddress(int Id)
        {
            var entity = new Address()
            {
                Id = Id
            };
            _context.Addresses.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
