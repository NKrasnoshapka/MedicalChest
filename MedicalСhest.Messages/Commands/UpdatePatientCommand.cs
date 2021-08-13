using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Messages.Commands
{
    public class UpdatePatientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
    }
}
