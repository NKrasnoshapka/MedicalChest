using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.DTOs
{
    public class PatinetDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

    }
}
