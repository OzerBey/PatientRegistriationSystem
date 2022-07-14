using System;
using System.Collections.Generic;

#nullable disable

namespace PatientRegistriationSystem.Entities
{
    public partial class Prescription
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int? PatientId { get; set; }
        public string Description { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
