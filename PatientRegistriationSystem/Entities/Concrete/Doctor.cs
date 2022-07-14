using System;
using System.Collections.Generic;
using PatientRegistriationSystem.Entities.Abstract;

#nullable disable

namespace PatientRegistriationSystem.Entities.Concrete
{
    public partial class Doctor : IEntity
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
