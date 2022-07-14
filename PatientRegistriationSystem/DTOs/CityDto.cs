using PatientRegistriationSystem.Entities;

namespace PatientRegistriationSystem.DTOs
{
    public class CityDto
    {
        public CityDto() => Addresses = new HashSet<AddressDto>();

        public string Name { get; set; }

        public virtual ICollection<AddressDto> Addresses { get; set; }
    }
}

