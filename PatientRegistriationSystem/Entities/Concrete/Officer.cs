using PatientRegistriationSystem.Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace PatientRegistriationSystem.Entities.Concrete
{
    public partial class Officer : IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
