using PatientRegistriationSystem.Entities;

namespace PatientRegistriationSystem.DTOs
{
    public class CityDto
    {
        public CityDto() => Addresses = new HashSet<Address>();

        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}

