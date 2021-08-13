using MediatR;
using MedicalСhest.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Messages.Queries
{
    public class PatientByIdQueries : IRequest<PatinetDTO>
    {
        public Guid Id { get; set; }
    }
}
