using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalСhest.DAL.Models
{
    public class Doctor
    {
        public Guid Id { get; set;}

        public string Organisation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public Specialisation Specialisation { get; set; }
    }
}
