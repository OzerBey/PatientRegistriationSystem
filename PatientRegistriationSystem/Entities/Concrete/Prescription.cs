using System;
using System.Collections.Generic;
using PatientRegistriationSystem.Entities.Abstract;

#nullable disable

namespace PatientRegistriationSystem.Entities.Concrete
{
    public partial class Prescription : IEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int? PatientId { get; set; }
        public string Description { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
