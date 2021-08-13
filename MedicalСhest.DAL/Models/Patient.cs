using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.Models
{
    public class Patient
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
