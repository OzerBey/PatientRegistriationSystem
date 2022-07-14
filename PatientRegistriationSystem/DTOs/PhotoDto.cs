using PatientRegistriationSystem.Entities.Concrete;

namespace PatientRegistriationSystem.DTOs
{
    public class PhotoDto
    {
        public string? Photo1 { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<Patient>? Patients { get; set; }
    }
}
