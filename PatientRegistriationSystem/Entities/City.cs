using System;
using System.Collections.Generic;

#nullable disable

namespace PatientRegistriationSystem.Entities
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
