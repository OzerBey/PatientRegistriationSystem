using System;
using System.Collections.Generic;

#nullable disable

namespace PatientRegistriationSystem.Entities
{
    public partial class Address
    {
        public Address()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public int? CityId { get; set; }
        public string Street { get; set; }
        public int BuildingNo { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
