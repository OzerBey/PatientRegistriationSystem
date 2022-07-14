using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientRegistriationSystem.Business;
using PatientRegistriationSystem.DTOs;
using PatientRegistriationSystem.Entities;
using PatientRegistriationSystem.Entities.Concrete;
using System.Net;

namespace PatientRegistriationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly patientregistrationsystemContext _context;
        public PhotoController(patientregistrationsystemContext DbContext)
        {
            this._context = DbContext;
        }
        //add photo
        [HttpPost("AddPhoto")]
        public async Task<HttpStatusCode> Add(PhotoDto photoDto)
        {
            var photoEncrypt = Md5.MD5Hash(photoDto.Photo1);
            var entity = new Photo()
            {
                Photo1 = photoEncrypt,
                Employees = photoDto.Employees,
                Patients = photoDto.Patients,
            };
            _context.Photos.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        //get photos by id
        [HttpGet("GetPhotoById")]
        public async Task<ActionResult<Photo>> GetPhotoById(int Id)
        {
            Photo photo = await _context.Photos.Select(s => new Photo
            {
                Id = s.Id
            }).FirstOrDefaultAsync(s => s.Id == Id);
            if (photo == null)
            {
                return NotFound();
            }
            else
            {
                return photo;
            }
        }

        //getAll
        [HttpGet("GetAllPhotos")]
        public async Task<ActionResult<IEnumerable<Photo>>> Get()
        {
            return await _context.Photos.ToListAsync();
        }
        //update Photo
        [HttpPut("UpdatePhoto")]
        public async Task<ActionResult<Photo>> UpdatePhoto(Photo photo)
        {
            var entity = await _context.Photos.FirstOrDefaultAsync(s => s.Id == photo.Id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.Photo1 = photo.Photo1;
                entity.Patients = photo.Patients;
                entity.Employees = photo.Employees;
                await _context.SaveChangesAsync();
                return entity;
            }
        }

        // delete photo
        //delete city
        [HttpDelete("DeletePhoto/{Id}")]
        public async Task<HttpStatusCode> DeletePhoto(int Id)
        {
            var entity = new Photo()
            {
                Id = Id
            };
            _context.Photos.Attach(entity);
            _context.Photos.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


    }
}
