using PatientRegistriationSystem.Entities;

namespace PatientRegistriationSystem.DTOs
{
    public class EmployeeDto
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EmployeeDto()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Doctors = new HashSet<Doctor>();
            Officers = new HashSet<Officer>();
        }
        public int AddressId { get; set; }
        public int NationalityId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int? PhotoId { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Officer> Officers { get; set; }
    }
}
