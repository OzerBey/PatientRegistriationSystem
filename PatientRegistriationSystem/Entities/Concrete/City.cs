using System;
using System.Collections.Generic;
using PatientRegistriationSystem.Entities.Abstract;

#nullable disable

namespace PatientRegistriationSystem.Entities.Concrete
{
    public partial class City : IEntity
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
