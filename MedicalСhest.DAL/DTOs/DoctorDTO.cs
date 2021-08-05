using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.DTOs
{
    public class DoctorDTO
    {
        public Guid Id { get; set; }
        public string Organisation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Specialisation { get; set; }
    }
}
