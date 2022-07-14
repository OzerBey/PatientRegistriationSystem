﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PatientRegistriationSystem.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int Id { get; set; }
        public int AddressId { get; set; }
        public int? NationalityId { get; set; }
        public string Name { get; set; }
        public int PhotoId { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual Address Address { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
