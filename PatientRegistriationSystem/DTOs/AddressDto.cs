using PatientRegistriationSystem.Entities;

namespace PatientRegistriationSystem.DTOs
{
    public class AddressDto
    {
        public int? CityId { get; set; }
        public string? Street { get; set; }
        public int BuildingNo { get; set; }
    }
}
