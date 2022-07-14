using System;
using System.Collections.Generic;

#nullable disable

namespace PatientRegistriationSystem.Entities
{
    public partial class Officer
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
