using MediatR;
using MedicalСhest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Messages.Commands
{
    public class AddNewDoctorCommand : IRequest<Unit>
    {
        public string Organisation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public Specialisation Specialisation { get; set; }
    }
}
