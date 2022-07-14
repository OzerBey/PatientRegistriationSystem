using System;
using System.Collections.Generic;

#nullable disable

namespace PatientRegistriationSystem.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Doctors = new HashSet<Doctor>();
            Officers = new HashSet<Officer>();
        }

        public int Id { get; set; }
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
