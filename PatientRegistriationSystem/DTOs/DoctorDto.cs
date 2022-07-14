using PatientRegistriationSystem.Entities.Concrete;

namespace PatientRegistriationSystem.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }

    }
}
