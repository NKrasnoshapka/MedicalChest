using MediatR;
using MedicalСhest.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Messages.Commands
{
    public class AddReceiptCommand : IRequest<Unit>
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public List<PrescriptionDTO> prescriptions { get; set; }
    }
}
