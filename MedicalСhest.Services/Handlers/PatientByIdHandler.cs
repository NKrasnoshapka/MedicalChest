using MediatR;
using MedicalСhest.DAL.Models;
using MedicalСhest.Messages.Queries;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MedicalСhest.DAL;
using MedicalСhest.DAL.DTOs;

namespace MedicalСhest.Services.Handlers
{
    public class PatientByIdHandler : IRequestHandler<PatientByIdQueries, PatinetDTO>
    {
        private readonly IMapper _mapper;
        private readonly MedicalСhestDBContext _medicalСhestDBContext;

        public PatientByIdHandler(IMapper mapper, MedicalСhestDBContext medicalСhestDBContext)
        {
            _medicalСhestDBContext = medicalСhestDBContext;
            _mapper = mapper;
        }

        public async Task<PatinetDTO> Handle(PatientByIdQueries query, CancellationToken cancellationToken)
        {
            var patient = await _medicalСhestDBContext.Patients.FindAsync(query.Id);
            return _mapper.Map<Patient, PatinetDTO>(patient);
        }
    }
}
