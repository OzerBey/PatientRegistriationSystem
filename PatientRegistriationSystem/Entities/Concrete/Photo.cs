using System;
using System.Collections.Generic;
using PatientRegistriationSystem.Entities.Abstract;
#nullable disable

namespace PatientRegistriationSystem.Entities.Concrete
{
    public partial class Photo : IEntity
    {
        public Photo()
        {
            Employees = new HashSet<Employee>();
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Photo1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
