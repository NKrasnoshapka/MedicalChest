using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Messages.Commands
{
    public class AssignDoctorCommand : IRequest<Unit>
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
    }
}
